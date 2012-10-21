using System;
using System.Collections.Generic;
using NGherkin.util;
using System.Reflection;
using System.IO;

namespace gherkin.util
{
public class FixJava {
    public static String join(List<String> strings, String separator) {
        return string.Join(separator, strings.ToArray());
    }

    public static List<R> map<T,R>(List<T> objects, Mapper<T,R> mapper) {
        throw new NotImplementedException();
    }

    public static String readResource(String resourcePath, Assembly assembly) {
        using (var stream = assembly.GetManifestResourceStream(resourcePath))
        {
            using (var reader = new StreamReader(stream))
            {
                string resource = reader.ReadToEnd();
                return resource;
            }
        }
    }

    public static String readReader(Reader reader) {
        throw new NotImplementedException();
    }
}
}