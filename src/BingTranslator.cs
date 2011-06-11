using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ResxTranslator.Properties;
using ResxTranslator.TranslatorSvc;

namespace ResxTranslator
{
    public class BingTranslator
    {
        public static void AutoTranslate(ResourceHolder resourceHolder, string languageCode)
        {
            string appID = Settings.Default.BingAppId;

            var toTranslate = new List<string>();

            foreach (DataRow row in resourceHolder.StringsTable.Rows)
            {
                if (!String.IsNullOrEmpty(row["NoLanguageValue"].ToString())
                    && (row[languageCode.ToLower()].ToString() == row["NoLanguageValue"].ToString()
                        || String.IsNullOrEmpty(row[languageCode.ToLower()].ToString())))
                {
                    toTranslate.Add(row["NoLanguageValue"].ToString());
                }
            }


            if (string.IsNullOrEmpty(appID))
            {
                return;
            }

            var svc = new LanguageServiceClient();

            TranslateArrayResponse[] translatedTexts
                = svc.TranslateArray(appID
                                     , toTranslate.ToArray()
                                     , Settings.Default.NeutralLanguageCode
                                     , languageCode.ToLower().Substring(0, 2)
                                     , new TranslateOptions());

            int i = 0;
            foreach (DataRow row in resourceHolder.StringsTable.Rows)
            {
                if (!String.IsNullOrEmpty(row["NoLanguageValue"].ToString())
                    && (row[languageCode.ToLower()].ToString() == row["NoLanguageValue"].ToString()
                        || String.IsNullOrEmpty(row[languageCode.ToLower()].ToString())))
                {
                    if (String.IsNullOrEmpty(translatedTexts[i].Error))
                    {
                        row[languageCode.ToLower()] = translatedTexts[i].TranslatedText;
                    }
                    ++i;
                }
            }
        }

        public static string GetDefaultLanguage(ResourceHolder resourceHolder)
        {
            string appID = Settings.Default.BingAppId;

            if (string.IsNullOrEmpty(appID))
            {
                return "";
            }
            var toTranslate = new List<string>();
            int cnt = 0;
            foreach (DataRow row in resourceHolder.StringsTable.Rows)
            {
                if (!String.IsNullOrEmpty(row["NoLanguageValue"].ToString())
                    && (row["NoLanguageValue"].ToString().Length > 10 || resourceHolder.StringsTable.Rows.Count < 10))
                {
                    toTranslate.Add(row["NoLanguageValue"].ToString());
                    cnt++;
                }
                if (cnt > 10)
                {
                    break;
                }
            }

            if (cnt == 0)
            {
                return "";
            }

            var svc = new LanguageServiceClient();
            TranslateArrayResponse[] translatedTexts = svc.TranslateArray(appID, toTranslate.ToArray(), Settings.Default.NeutralLanguageCode, "en", new TranslateOptions());
            
            // find most frequent language
            var maxArr = translatedTexts
                .GroupBy(t => t.From)
                .Select(grp => new { Language = grp.Key, Count = grp.Count() })
                .OrderByDescending(y => y.Count);

            return maxArr.First().Language;
        }

        public static string TranslateString(string src, string to)
        {
            string appID = Settings.Default.BingAppId;
            var svc = new LanguageServiceClient();
            string tolanguage = string.IsNullOrEmpty(to.Trim()) ? "" : (to.Trim() + "  ").Substring(0, 2);
            var translateOptions = new TranslateOptions();
            translateOptions.ContentType = "text/html";
            translateOptions.Category = "general";

            TranslateArrayResponse[] translatedTexts = svc.TranslateArray(appID, new[] { src }, Settings.Default.NeutralLanguageCode, tolanguage, translateOptions);

            return translatedTexts[0].TranslatedText;
        }
    }
}