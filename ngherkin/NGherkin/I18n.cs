using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using gherkin.util;
using gherkin.lexer;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace gherkin
{
    public class I18n
    {
        private static List<String> FEATURE_ELEMENT_KEYWORD_KEYS = new List<string> { "feature", "background", "scenario", "scenario_outline", "examples" };
        private static List<String> STEP_KEYWORD_KEYS = new List<string> { "given", "when", "then", "and", "but" };
        private static List<String> KEYWORD_KEYS = new List<string>();

        private static Dictionary<String, Dictionary<String, String>> I18N;

        static I18n()
        {
            KEYWORD_KEYS.AddRange(FEATURE_ELEMENT_KEYWORD_KEYS);
            KEYWORD_KEYS.AddRange(STEP_KEYWORD_KEYS);

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gherkin.i18n.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    I18N = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                }
            }
        }

        private String isoCode;
        private Locale locale;
        private Dictionary<String, List<String>> _keywords;

        public static String codeKeywordFor(String keyword)
        {
            throw new NotImplementedException();
        }

        public I18n(String isoCode)
        {
            this.isoCode = isoCode;
            this.locale = localeFor(this.isoCode);
            this._keywords = new Dictionary<String, List<String>>();

            Dictionary<String, String> keywordMap = I18N[isoCode];
            foreach (var entry in keywordMap)
            {
                List<String> keywordList = entry.Value.Split(new string[] { "\\|" }, StringSplitOptions.None).ToList();
                if (STEP_KEYWORD_KEYS.Contains(entry.Key))
                {
                    List<String> stepKeywords = new List<String>();
                    foreach (String s in keywordList)
                    {
                        stepKeywords.Add((s + " ").ReplaceFirst("< $", ""));
                    }
                    keywordList = stepKeywords;
                }
                this._keywords[entry.Key] = new List<string>(keywordList);
            }
        }

        public String getIsoCode()
        {
            return this.isoCode;
        }

        public CultureInfo getLocale()
        {
            throw new NotImplementedException();
        }

        public String getUnderscoredIsoCode()
        {
            return getIsoCode().Replace("[\\s-]", "_").ToLower();
        }

        private String capitalize(String s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        public Lexer lexer(Listener listener)
        {
            String qualifiedI18nLexerClassName = "gherkin.lexer." + capitalize(getUnderscoredIsoCode());
            try
            {
                var type = Type.GetType(qualifiedI18nLexerClassName);
                return (Lexer)Activator.CreateInstance(type, listener);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Couldn't load lexer class: " + qualifiedI18nLexerClassName, e);
            }
        }

        public List<String> keywords(String key)
        {
            throw new NotImplementedException();
        }

        public List<String> getCodeKeywords()
        {
            throw new NotImplementedException();
        }

        public List<String> getStepKeywords()
        {
            throw new NotImplementedException();
        }

        public String getKeywordTable()
        {
            throw new NotImplementedException();
        }

        private Locale localeFor(String isoString)
        {
            String[] languageAndCountry = isoString.Split('-');
            if (languageAndCountry.Length == 1)
            {
                return new Locale(isoString);
            }
            else
            {
                return new Locale(languageAndCountry[0], languageAndCountry[1]);
            }
        }
    }
}