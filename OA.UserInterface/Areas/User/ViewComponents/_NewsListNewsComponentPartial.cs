using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Concrete;
using OA.EntityLayer.Requests.ArticleRequests;
using OA.UserInterface.Models;
using System.Text;

namespace OA.UserInterface.Areas.User.ViewComponents
{
    public class _NewsListNewsComponentPartial : ViewComponent
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly ApiSettings _apiSettings;

        public _NewsListNewsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int tagId, bool dateOption)
        {
            //If filter works
            var clientFilter = _httpClientFactory.CreateClient();
            clientFilter.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var jsonDataFilter = JsonConvert.SerializeObject(new { categoryId, dateOption });
            StringContent content = new StringContent(jsonDataFilter, Encoding.UTF8, "application/json");
            var responseFilter = await clientFilter.GetAsync($"Article/GetFilteredNewsByCategoryAndDate?categoryId={categoryId}&dateOpt={dateOption}");

            if (responseFilter.IsSuccessStatusCode && categoryId != 0)
            {
                var responseJsonData = await responseFilter.Content.ReadAsStringAsync();
                var filteredNews = JsonConvert.DeserializeObject<List<ResultArticleRequest>>(responseJsonData);
                return View(filteredNews);
            }
            //ends

            //If tag works
            if (tagId > 0)
            {
                var tagClient = _httpClientFactory.CreateClient();
                tagClient.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
                var tagJsonData = JsonConvert.SerializeObject(new { tagId });
                StringContent tagContent = new StringContent(tagJsonData, Encoding.UTF8, "application/json");
                var tagResponse = await tagClient.GetAsync($"Article/GetFilteredNewsByTag?tagId={tagId}");

                if (tagResponse.IsSuccessStatusCode && tagId != 0)
                {
                    var responseJsonData = await tagResponse.Content.ReadAsStringAsync();
                    var filteredNews = JsonConvert.DeserializeObject<List<ResultArticleRequest>>(responseJsonData);
                    return View(filteredNews);
                }
            }
            //ends

            //if filter does not work
            var clientNoFilter = _httpClientFactory.CreateClient();
            clientNoFilter.BaseAddress = new Uri(_apiSettings.BaseHostUrl!);
            var responseNoFilter = await clientNoFilter.GetAsync("Article/GetResultArticles");

            if (responseNoFilter.IsSuccessStatusCode)
            {
                var jsonDataNoFilter = await responseNoFilter.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultArticleRequest>>(jsonDataNoFilter);
                return View(values);
            }
            //ends

            return View();
        }
    }
}
