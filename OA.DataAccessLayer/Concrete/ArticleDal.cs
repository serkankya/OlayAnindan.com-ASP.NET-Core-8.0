using Dapper;
using Microsoft.Extensions.Logging;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;
using System.Data.SqlClient;

namespace OA.DataAccessLayer.Concrete
{
    public class ArticleDal : GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>, IArticleDal
    {
        readonly IDapperContext _dapperContext;
        readonly ILogger _logger;

        public ArticleDal(ISqlToolsProvider sqlToolsProvider, IDapperContext dapperContext, ILogger<GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>> logger)
            : base(sqlToolsProvider, dapperContext, logger)
        {
            _dapperContext = dapperContext;
            _logger = logger;
        }

        public async Task<List<ResultArticleRequest>> GetFeaturedNews()
        {
            using (var connection = _dapperContext.GetConnection())
            {
                string queryForFeatureds = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.IsFeatured = 1";

                var values = await connection.QueryAsync<ResultArticleRequest>(queryForFeatureds);
                return values.ToList();
            }
        }

        public async Task<List<ResultArticleRequest>> GetLatestNews()
        {
            using (var connection = _dapperContext.GetConnection())
            {
                string queryForLatestNews = "SELECT TOP(12)* FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId ORDER BY a.CreatedAt DESC";

                var values = await connection.QueryAsync<ResultArticleRequest>(queryForLatestNews);
                return values.ToList();
            }
        }

        public async Task<List<ResultArticleRequest>> GetMainNewsHighlights()
        {
            using (var connection = _dapperContext.GetConnection())
            {
                string queryForMainNews = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.IsMainNews = 1";

                var values = await connection.QueryAsync<ResultArticleRequest>(queryForMainNews);
                return values.ToList();
            }
        }

        public async Task<List<ResultArticleRequest>> GetFilteredNewsByCategoryAndDate(int categoryId, bool dateOption)
        {
            //if dateOption == false this means news will start from oldest
            //if dateOption == true this means news will start from newest

            using (var connection = _dapperContext.GetConnection())
            {
                //oldest
                string queryForCategoryAndDateASC = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.CategoryId = @categoryId ORDER BY CreatedAt ASC";

                //newest				
                string queryForCategoryAndDateDESC = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId WHERE a.CategoryId = @categoryId ORDER BY CreatedAt DESC";

                var parameters = new DynamicParameters();
                parameters.Add("@categoryId", categoryId);

                // Return based on the date option
                if (dateOption == true)
                {
                    //newest
                    var values = await connection.QueryAsync<ResultArticleRequest>(queryForCategoryAndDateDESC, parameters);
                    return values.ToList();
                }
                else
                {
                    //oldest
                    var values = await connection.QueryAsync<ResultArticleRequest>(queryForCategoryAndDateASC, parameters);
                    return values.ToList();
                }
            }
        }

        public async Task<ResultArticleRequest> GetResultArticleById(int articleId)
        {
            using (var connection = _dapperContext.GetConnection())
            {
                string queryForArticle = "SELECT * FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId INNER JOIN Users u ON u.UserId = a.UserId WHERE a.ArticleId = @articleId AND (a.Status = 1 AND m.Status = 1)";

                var parameters = new DynamicParameters();
                parameters.Add("@articleId", articleId);

                var value = await connection.QueryFirstOrDefaultAsync<ResultArticleRequest>(queryForArticle, parameters);

                if (value == null)
                {
                    return new ResultArticleRequest
                    {
                        ArticleId = 0,
                        MainTitle = "Article not found or inactive!"
                    };
                }

                return value;
            }
        }

        public async Task<List<ResultArticleRequest>> GetResultArticles()
        {
            using (var connection = _dapperContext.GetConnection())
            {
                string queryForArticles = "SELECT a.*, m.*, u.Username, u.FullName, u.ImageUrl, u.Email, u.RoleId FROM Articles a INNER JOIN Medias m ON a.ArticleId = m.ArticleId INNER JOIN Users u ON u.UserId = a.UserId WHERE a.Status = 1 AND m.Status = 1 ORDER BY a.CreatedAt DESC";

                var values = await connection.QueryAsync<ResultArticleRequest>(queryForArticles);
                return values.ToList();
            }
        }

        public async Task<bool> InsertTransaction(InsertArticleTransactionRequest insertArticleTransactionRequest)
        {
            try
            {
                using (var connection = _dapperContext.GetConnection())
                {
                    connection.Open();

                    using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                    {
                        try
                        {
                            #region Articles
                            string queryForArticle = "INSERT INTO Articles (UserId, CategoryId, MainTitle, MainText, FirstTitle, FirstText, SecondTitle, SecondText, Summary, IsFeatured) VALUES (@userId, @categoryId, @mainTitle, @mainText, @firstTitle, @firstText, @secondTitle, @secondText, @summary, @isFeatured); SELECT SCOPE_IDENTITY();";

                            var parametersForArticle = new DynamicParameters();
                            parametersForArticle.Add("@userId", insertArticleTransactionRequest.UserId);
                            parametersForArticle.Add("@categoryId", insertArticleTransactionRequest.CategoryId);
                            parametersForArticle.Add("@mainTitle", insertArticleTransactionRequest.MainTitle);
                            parametersForArticle.Add("@mainText", insertArticleTransactionRequest.MainText);
                            parametersForArticle.Add("@firstTitle", insertArticleTransactionRequest.FirstTitle);
                            parametersForArticle.Add("@firstText", insertArticleTransactionRequest.FirstText);
                            parametersForArticle.Add("@secondTitle", insertArticleTransactionRequest.SecondTitle);
                            parametersForArticle.Add("@secondText", insertArticleTransactionRequest.SecondText);
                            parametersForArticle.Add("@summary", insertArticleTransactionRequest.Summary);
                            parametersForArticle.Add("@isFeatured", insertArticleTransactionRequest.IsFeatured);

                            int insertedArticleId = await connection.QuerySingleAsync<int>(queryForArticle, parametersForArticle, sqlTransaction);
                            #endregion

                            #region Tags
                            string queryForTags = "INSERT INTO Tags (TagName) VALUES (@tagName); SELECT SCOPE_IDENTITY();";

                            List<int> TagIds = new List<int>();

                            var parametersForTags = new DynamicParameters();
                            for (int i = 0; i < insertArticleTransactionRequest.TagName.Count; i++)
                            {
                                parametersForTags.Add("@tagName", insertArticleTransactionRequest.TagName[i]);

                                int insertedTagId = await connection.QuerySingleAsync<int>(queryForTags, parametersForTags, sqlTransaction);
                                TagIds.Add(insertedTagId);
                            }
                            #endregion

                            #region ArticleTags
                            string queryForArticleTags = "INSERT INTO ArticleTags (ArticleId, TagId) VALUES (@articleId, @tagId)";

                            var parametersForArticleTags = new DynamicParameters();

                            for (int i = 0; i < TagIds.Count; i++)
                            {
                                parametersForArticleTags.Add("@articleId", insertedArticleId);
                                parametersForArticleTags.Add("@tagId", TagIds[i]);

                                await connection.ExecuteAsync(queryForArticleTags, parametersForArticleTags, sqlTransaction);
                            }
                            #endregion

                            #region Medias
                            string queryForMedias = "INSERT INTO Medias (ArticleId, MainMediaPath, MainMediaType, FirstMediaPath, FirstMediaType, SecondMediaPath, SecondMediaType) VALUES (@articleId, @mainMediaPath, @mainMediaType, @firstMediaPath, @firstMediaType, @secondMediaPath, @secondMediaType)";

                            var parametersForMedias = new DynamicParameters();
                            parametersForMedias.Add("@articleId", insertedArticleId);
                            parametersForMedias.Add("@mainMediaPath", insertArticleTransactionRequest.MainMediaPath);
                            parametersForMedias.Add("@mainMediaType", insertArticleTransactionRequest.MainMediaType);
                            parametersForMedias.Add("@firstMediaPath", insertArticleTransactionRequest.FirstMediaPath);
                            parametersForMedias.Add("@firstMediaType", insertArticleTransactionRequest.FirstMediaType);
                            parametersForMedias.Add("@secondMediaPath", insertArticleTransactionRequest.SecondMediaPath);
                            parametersForMedias.Add("@secondMediaType", insertArticleTransactionRequest.SecondMediaType);

                            int rowsEffected = await connection.ExecuteAsync(queryForMedias, parametersForMedias, sqlTransaction);
                            #endregion

                            sqlTransaction.Commit();
                            return rowsEffected > 0;
                        }
                        catch
                        {
                            sqlTransaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting article.");
                return false;
            }
        }
    }
}
