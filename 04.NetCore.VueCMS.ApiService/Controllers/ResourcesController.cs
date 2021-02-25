using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NetCore.VueCMS.ApiService.Controllers
{
    /// <summary>
    /// 出参Model
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// 状态码，建议跟HTTP状态码一致
        /// </summary>
        public int Code { get; set; } = 200;
        /// <summary>
        /// 返回的文字消息
        /// </summary>
        public string Msg { get; set; } = "成功";
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 返回的条数
        /// </summary>
        public int Total { get; set; }

    }



    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {

        public IConfiguration ConfigurationHelper { get; }
        public string rooturl { get; set; }
        public string ProgramRootPath = System.IO.Directory.GetCurrentDirectory();
        public ResourcesController(IConfiguration configuration)
        {
            ConfigurationHelper = configuration;
            rooturl = ConfigurationHelper.GetSection("RootUrl").Value;
        }


        /// <summary>
        /// 获取轮播图数据
        /// </summary>
        /// <remarks>
        /// 例子：
        /// GET api/Resources/GetSwipe
        /// </remarks>
        /// <returns>SwipeModel</returns>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetSwipe()
        {
            var ret = new ApiResponse();
            var cc = new List<SwipeModel>() {
                new SwipeModel(){ ID = "1",Url= rooturl+"/Resources/images/mint-swipe1.jpg"},
                new SwipeModel(){ ID = "2",Url= rooturl+"/Resources/images/mint-swipe2.jpg"},
                new SwipeModel(){ ID = "3",Url= rooturl+"/Resources/images/mint-swipe3.jpg"}
            };
            ret.Total = cc.Count;
            ret.Data = Newtonsoft.Json.JsonConvert.SerializeObject(cc);

            return ret;

        }

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <remarks>
        /// 例子：
        /// GET api/Resources/GetNewsList
        /// </remarks>
        /// <returns>NewsListModel</returns>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetNewsList()
        {
            var ret = new ApiResponse();
            var cc = new List<NewsListModel>();

            for (int i = 0; i < 50; i++)
            {
                var newsListModel = new NewsListModel
                {
                    ID = i,
                    Title = i + "习近平向第六届世界互联网大会致贺信",
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Memo = i + "习近平向第六届世界互联网大会致贺信" + i + "习近平向第六届世界互联网大会致贺信" + i + "习近平向第六届世界互联网大会致贺信",
                    ClickNumber = new Random().Next(1, 100),//1~100 随机数
                    ImgUrl = rooturl + "/Resources/images/mint-swipe1.jpg"
                };
                cc.Add(newsListModel);
            }
            ret.Total = cc.Count;
            ret.Data = Newtonsoft.Json.JsonConvert.SerializeObject(cc);

            return ret;
        }

        /// <summary>
        /// 根据ID获取新闻详情
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <remarks>
        /// 例子：
        /// GET api/Resources/GetNewsInfoByID
        /// </remarks>
        /// <returns>NewsInfoModel</returns>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetNewsInfoByID(string id)
        {
            var ret = new ApiResponse();
            var cc = new List<NewsInfoModel>();
            try
            {

                string path = ProgramRootPath + "\\wwwroot\\DataJsonFile\\Newsinfo.txt";
                string contents = System.IO.File.ReadAllText(path, Encoding.UTF8);
                for (int i = 0; i < 50; i++)
                {
                    var newsListModel = new NewsInfoModel
                    {
                        ID = i,
                        Title = i + "习近平向第六届世界互联网大会致贺信",
                        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        ClickNumber = new Random().Next(1, 100),//1~100 随机数
                        Contents = contents

                    };
                    cc.Add(newsListModel);
                }
            }
            catch (Exception ex)
            {
                ret.Code = 500;
                ret.Msg = ex.Message;
                //throw ex;
            }
            ret.Total = cc.Count;
            ret.Data = cc.Find(s => s.ID.ToString().Equals(id));
            return ret;
        }


        /// <summary>
        /// 获取评论数据
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <param name="pageIndex">分页</param>
        /// <param name="pageSize">分页</param>
        /// <returns></returns>
        /// <remarks>
        /// 例子：
        /// GET api/Resources/GetNewsInfoByID
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetComment(string id = "", int pageIndex = 0, int pageSize = 10)
        {
            var ret = new ApiResponse();
            var cc = new List<CommentModel>();
            for (int i = 1; i < 51; i++)
            {
                var newsListModel = new CommentModel
                {
                    ID = i,
                    UserName = "匿名用户" + i,
                    Content = i + "习近平向第六届世界互联网大会致贺信",
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                cc.Add(newsListModel);
            }
            ret.Total = cc.Count;
            ret.Data = cc.AsQueryable().Skip(pageIndex * pageSize).Take(pageSize).ToList();


            return ret;

        }


        /// <summary>
        /// 发表评论
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 例子：
        /// POST  api/Resources/SaveComment
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpPost]
        public ApiResponse SaveComment(CommentModel model)
        {
            var ret = new ApiResponse();
            ret.Data = model;
            return ret;
        }

        /// <summary>
        /// 获取图片类型
        /// </summary>
        /// <remarks>
        /// 例子：
        /// GET  api/Resources/GetPhotoCategory
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetPhotoCategory()
        {
            var ret = new ApiResponse();
            List<CategoryModel> category = new List<CategoryModel>() {
                new CategoryModel(){ID = 0,CategoryName = "全部"},
                new CategoryModel(){ID = 1,CategoryName = "今日热图"},
                new CategoryModel(){ID = 2,CategoryName = "明星"},
                new CategoryModel(){ID = 3,CategoryName = "美女"},
                new CategoryModel(){ID = 4,CategoryName = "摄影"},
                new CategoryModel(){ID = 5,CategoryName = "壁纸"},
                new CategoryModel(){ID = 6,CategoryName = "动漫"}
            };
            ret.Total = category.Count;
            ret.Data = category;
            return ret;

        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// 例子：
        /// GET  api/Resources/GetPhotoListByCategoryID
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetPhotoListByCategoryID(string categoryID)
        {
            var ret = new ApiResponse();
            string path = ProgramRootPath + "\\wwwroot\\Resources\\images\\photoshare_img";
            List<ImagesModel> list = new List<ImagesModel>();
            int num = 1;

            //1.获取对应路径下所有文件夹的名称
            string[] directory = Directory.GetDirectories(path);
            foreach (var item in directory)
            {
                //2.循环获取对应路径下文件夹的信息
                DirectoryInfo directoryInfo = new DirectoryInfo(item);
                //3.获取对应路径文件夹下的文件信息
                FileInfo[] fileInfo = directoryInfo.GetFiles();
                //4.循环获取每项文件的内容
                foreach (var items in fileInfo)
                {
                    var cc = new ImagesModel();
                    cc.ID = num++;
                    cc.CategoryID = Convert.ToInt32(directoryInfo.Name);
                    cc.ImgUrl = rooturl + "/Resources/images/photoshare_img/" + directoryInfo.Name + "/" + items.Name;
                    cc.Title = cc.ID + ":我总在牛A和牛C之间徘徊";
                    cc.Summary = cc.ID + ":我是小妖怪，逍遥又自在，杀人不眨眼，吃人不放盐，一口七八个，肚皮要撑破，茅房去拉屎，想起忘带纸。生活你全是泪，没死就得活受罪，越是折腾越倒霉，越有追求越悲催，垂死挣扎你累不累，不如瘫在床上睡。来来回回千百遍，小爷也是很疲倦 ";
                    cc.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cc.ClickNumber = new Random().Next(1, 100);//1~100 随机数
                    list.Add(cc);
                }
            }
            ret.Total = list.Count;

            if (!string.IsNullOrEmpty(categoryID) && Convert.ToInt32(categoryID) != 0)
                list = list.Where(s => s.CategoryID.Equals(Convert.ToInt32(categoryID))).ToList();
            ret.Data = list;


            return ret;
        }


        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <remarks>
        /// 例子：
        /// GET  api/Resources/GetGoodsList
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetGoodsList(int pageIndex = 0, int pageSize = 10)
        {
            var ret = new ApiResponse();
            string path = ProgramRootPath + "\\wwwroot\\Resources\\images\\goods_img";
            List<GoodsModel> list = new List<GoodsModel>();
            int num = 1;
            //2.循环获取对应路径下文件夹的信息
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            //3.获取对应路径文件夹下的文件信息
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            //4.循环获取每项文件的内容
            foreach (var items in fileInfo)
            {
                var cc = new GoodsModel();
                cc.ID = num++;
                cc.ImgUrl = rooturl + "/Resources/images/goods_img/" + items.Name;
                cc.Title = cc.ID + ":生死看淡，不服就干 小米11.11 低价提前享 预售狂欢  666666.......";
                cc.Num = new Random().Next(1, 1000);//1~100 随机数
                cc.NowPrice = new Random().Next(3000, 5000).ToString();//1~100 随机数;
                cc.OldPrice = new Random().Next(1000, 3000).ToString();
                list.Add(cc);
            }

            ret.Total = list.Count;
            ret.Data = list.Skip(pageIndex * pageSize).Take(pageSize).ToList();


            return ret;

        }


        /// <summary>
        /// 获取商品详情页面图文介绍
        /// </summary>
        /// <remarks>
        /// 例子：
        /// GET  api/Resources/GetGoodsInfoDesc
        /// </remarks>
        /// <response code="200">返回成功的数据，json 或者 数组格式</response>
        [HttpGet]
        public ApiResponse GetGoodsInfoDesc()
        {
            var ret = new ApiResponse();
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            string path = ProgramRootPath + "\\wwwroot\\Resources\\images\\goodsinfo_desc_img";
            //2.循环获取对应路径下文件夹的信息
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            //3.获取对应路径文件夹下的文件信息
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            //4.循环获取每项文件的内容
            foreach (var items in fileInfo)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    { "url", rooturl + "/Resources/images/goodsinfo_desc_img/" + items.Name }
                };
                list.Add(dic);
            }

            ret.Total = list.Count;
            ret.Data = list;
            return ret;

        }




        /// <summary>
        /// 测试方法:HttpPut 请求
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <remarks>
        /// 例：
        /// api/Resources/TestHttpPut
        /// </remarks>
        [HttpPut]
        public ApiResponse TestHttpPut(string ID)
        {
            var ret = new ApiResponse();
            ret.Data = ID;
            return ret;
        }

        /// <summary>
        /// 测试方法:HttpDelete 请求
        /// </summary>
        /// <param name="ID"></param>
        /// <remarks>
        /// 例：
        /// api/Resources/TestHttpPut
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        public ApiResponse TestHttpDelete(string ID)
        {
            var ret = new ApiResponse();
            ret.Data = ID;
            return ret;
        }



    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 轮播Model
    /// </summary>
    public class SwipeModel
    {
        public string ID { get; set; }
        public string Url { get; set; }

    }

    /// <summary>
    /// 新闻列表Model
    /// </summary>
    public class NewsListModel
    {
        /// <summary>
        /// 资讯ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int ClickNumber { get; set; }
        /// <summary>
        /// 图片路径    
        /// </summary>
        public string ImgUrl { get; set; }


    }

    /// <summary>
    /// 新闻详情Model
    /// </summary>
    public class NewsInfoModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ClickNumber { get; set; }
        public string CreateTime { get; set; }
        public string Contents { get; set; }
    }

    /// <summary>
    /// 评论Model
    /// </summary>
    public class CommentModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string CreateTime { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// 图片类型Model
    /// </summary>
    public class CategoryModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }

    /// <summary>
    /// 图片Model
    /// </summary>
    public class ImagesModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Summary { get; set; }
        public string CreateTime { get; set; }
        public int ClickNumber { get; set; }
    }


    /// <summary>
    /// 商品Model
    /// </summary>
    public class GoodsModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string NowPrice { get; set; }
        public string OldPrice { get; set; }
        public int Num { get; set; }

    }










}