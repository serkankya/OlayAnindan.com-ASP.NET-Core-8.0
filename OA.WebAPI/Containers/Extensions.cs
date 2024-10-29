using FluentValidation;
using OA.BusinessLayer.Abstract;
using OA.BusinessLayer.Abstract.Dapper;
using OA.BusinessLayer.Abstract.GenericRepository;
using OA.DataAccessLayer.Concrete;
using OA.DataAccessLayer.Concrete.Dapper;
using OA.DataAccessLayer.Concrete.GenericRepository;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRatingRequests;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.EntityLayer.Requests.ArticleTagRequests;
using OA.EntityLayer.Requests.AuditLogRequests;
using OA.EntityLayer.Requests.CategoryRequests;
using OA.EntityLayer.Requests.CommentRequests;
using OA.EntityLayer.Requests.ContactMessageRequests;
using OA.EntityLayer.Requests.MediaRequests;
using OA.EntityLayer.Requests.NotificationRequests;
using OA.EntityLayer.Requests.RoleRequests;
using OA.EntityLayer.Requests.TagRequests;
using OA.EntityLayer.Requests.UserRequests;
using OA.WebAPI.FluentValidation;

namespace OA.WebAPI.Containers
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddTransient<IDapperContext, DapperContext>();
			services.AddTransient<ISqlToolsProvider, SqlToolsProvider>();

			services.AddTransient<IGenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>, GenericRepository<Role, InsertRoleRequest, UpdateRoleRequest>>();
			services.AddTransient<IGenericRepository<User, InsertUserRequest, UpdateUserRequest>, GenericRepository<User, InsertUserRequest, UpdateUserRequest>>();
			services.AddTransient<IGenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>, GenericRepository<Article, InsertArticleRequest, UpdateArticleRequest>>();
			services.AddTransient<IGenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>, GenericRepository<ArticleRating, InsertArticleRatingRequest, UpdateArticleRatingRequest>>();
			services.AddTransient<IGenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>, GenericRepository<ArticleTag, InsertArticleTagRequest, UpdateArticleTagRequest>>();
			services.AddTransient<IGenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest>, GenericRepository<AuditLog, InsertLogRequest, UpdateLogRequest>>();
			services.AddTransient<IGenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>, GenericRepository<Category, InsertCategoryRequest, UpdateCategoryRequest>>();
			services.AddTransient<IGenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>, GenericRepository<Comment, InsertCommentRequest, UpdateCommentRequest>>();
			services.AddTransient<IGenericRepository<Media, InsertMediaRequest, UpdateMediaRequest>, GenericRepository<Media, InsertMediaRequest, UpdateMediaRequest>>();
			services.AddTransient<IGenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest>, GenericRepository<Notification, InsertNotificationRequest, UpdateNotificationRequest>>();
			services.AddTransient<IGenericRepository<Tag, InsertTagRequest, UpdateTagRequest>, GenericRepository<Tag, InsertTagRequest, UpdateTagRequest>>();
			services.AddTransient<IGenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>, GenericRepository<ContactMessage, InsertContactMessageRequest, UpdateContactMessageRequest>>();


            services.AddTransient<ILoginDal, LoginDal>();
			services.AddTransient<IUserDal, UserDal>();
			services.AddTransient<IArticleDal, ArticleDal>();
			services.AddTransient<IArticleTagDal, ArticleTagDal>();
			services.AddTransient<ICommentDal, CommentDal>();
			services.AddTransient<ICategoryDal, CategoryDal>();

			//Fluent validation validators
			services.AddValidatorsFromAssemblyContaining<UserValidator>();
			services.AddValidatorsFromAssemblyContaining<ArticleValidator>();
			services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
			services.AddValidatorsFromAssemblyContaining<CommentValidator>();
			services.AddValidatorsFromAssemblyContaining<LoginValidator>();
			services.AddValidatorsFromAssemblyContaining<RoleValidator>();
			services.AddValidatorsFromAssemblyContaining<TagValidator>();
		}
	}
}
