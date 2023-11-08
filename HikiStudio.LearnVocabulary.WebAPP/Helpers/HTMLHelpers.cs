using Microsoft.AspNetCore.Mvc.Rendering;

namespace HikiStudio.LearnVocabulary.WebAPP.Helpers
{
    public static class HTMLHelpers
    {
        /// <summary>
        /// Active Menu SideBar with controller
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static string IsActive(this IHtmlHelper htmlHelper, string controller, string cssClass = "active")
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var routeController = routeData?.Values["controller"]?.ToString();
            var returnActive = (controller == routeController);

            return returnActive ? cssClass : "";
        }

        /// <summary>
        /// Active Menu SideBar with controller and action
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IsActiveWithAction(this IHtmlHelper htmlHelper, string controller, string action, string cssClass = "active")
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData?.Values["action"]?.ToString();
            var routeController = routeData?.Values["controller"]?.ToString();
            var returnActive = (controller == routeController && action == routeAction);

            return returnActive ? cssClass : "";
        }

        /// <summary>
        /// Convert String To UnSign
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToUnSign(this IHtmlHelper htmlHelper, string str)
        {
            //return StringHelper.ConvertToUnSign(str);
            return "";
        }


        /// <summary>
        /// Convert Datetime to Date with format MM/dd/yyyy
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="date"></param>
        /// <returns></returns>

        public static string ConvertDate(this IHtmlHelper htmlHelper, DateTime date)
        {
            return date.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Convert Datetime with format MM/dd/yyyy h:mm tt
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="date"></param>
        /// <returns></returns>

        public static string? ConvertDateTime(this IHtmlHelper htmlHelper, DateTime? date)
        {
            return date?.ToString("MM/dd/yyyy h:mm tt");
        }
    }
}
