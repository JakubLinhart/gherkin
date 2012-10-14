using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace gherkin.formatter
{
    [TestClass]
    public class MappableTest
    {
        public class TestMappable : Mappable
        {
            public int an_int = 1;
            public long a_long = 2L;
            public String a_string = "3";
            public AnotherMappable a_mappable = new AnotherMappable();
            public List<short> a_short_list = new List<short>() { (short)4, (short)5, (short)6 };
            public List<AnotherMappable> a_mappable_list = new List<AnotherMappable> { new AnotherMappable() };
            public Object an_int_declared_as_object = 7;

            [NonSerialized]
            public int a_transient_int = 1;

            // Non-mappable
            public Uri an_url;
            public List<Type> a_class_list = new List<Type>() { typeof(string) };

            public TestMappable()
            {
                an_url = new Uri("http://cukes.info/");
            }
        }

        public class AnotherMappable : Mappable
        {
            public int another_int = 4;
            public byte a_byte = 5;
            public Type a_class = typeof(AnotherMappable);
        }

        [TestMethod]
        public void should_not_include_NotSerialized_fields()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            Assert.IsFalse(map.ContainsKey("a_transient_int"));
        }

        [TestMethod]
        public void should_not_include_object_fields()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            Assert.IsFalse(map.ContainsKey("an_int_declared_as_object"));
        }

        [TestMethod]
        public void should_include_collection_of_primitives()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            var shortList = (IEnumerable<object>)map["a_short_list"];

            Assert.IsNotNull(shortList);
            Assert.AreEqual(3, shortList.Count());
        }

        [TestMethod]
        public void should_include_collection_of_mappable()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            Assert.IsTrue(map.ContainsKey("a_mappable_list"));
        }

        [TestMethod]
        public void should_include_mappable()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            Assert.IsTrue(map.ContainsKey("a_mappable"));
        }

        [TestMethod]
        public void should_only_include_primitives_strings_mappables_and_collections_of_mappable()
        {
            TestMappable tm = new TestMappable();
            Dictionary<Object, Object> map = tm.toMap();

            String expected = "" +
                    "{\n" +
                    "  \"an_int\":1,\n" +
                    "  \"a_long\":2,\n" +
                    "  \"a_string\":\"3\",\n" +
                    "  \"a_mappable\":{\n" +
                    "    \"another_int\":4,\n" +
                    "    \"a_byte\":5\n" +
                    "  },\n" +
                    "  \"a_short_list\":[\n" +
                    "    4,\n" +
                    "    5,\n" +
                    "    6\n" +
                    "  ],\n" +
                    "  \"a_mappable_list\":[\n" +
                    "    {\n" +
                    "      \"another_int\":4,\n" +
                    "      \"a_byte\":5\n" +
                    "    }\n" +
                    "  ]\n" +
                    "}\n";

            var serializedMap = JsonConvert.SerializeObject(map, new KeyValuePairConverter());

            Assert.AreEqual(RemoveWhiteSpaces(expected), RemoveWhiteSpaces(serializedMap));
        }

        private static string RemoveWhiteSpaces(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (!char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

    }
}