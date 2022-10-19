using Core.Translation.Services;

namespace Core.Translation.Extension
{
    public static class StringExtension
    {
        public static string Translate(this string value, string localeCode)
        {
            var translateService = new TranslateService();

            return translateService.Translate(value, localeCode).GetAwaiter().GetResult();
        }
    }
}
