﻿using OA.BusinessLayer.Abstract.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.BusinessLayer.Abstract
{
	public interface IArticleDal : IGenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>
	{
		Task<List<ResultArticleRequest>> GetResultArticles();
		Task<ResultArticleRequest> GetResultArticleById(int articleId);
		Task<bool> InsertTransaction(InsertArticleTransactionRequest insertArticleTransactionRequest);
		Task<List<ResultArticleRequest>> GetMainNewsHighlights();
		Task<List<ResultArticleRequest>> GetFeaturedNews();
		Task<List<ResultArticleRequest>> GetLatestNews();
		Task<List<ResultArticleRequest>> GetFilteredNewsByCategoryAndDate(int categoryId, bool dateOption);
	}
}
