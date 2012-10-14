using System.Collections.Generic;
using System;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace gherkin.formatter
{
    public class Mappable
    {
        private readonly int NO_LINE = -1;

        private bool isMappableType(MemberInfo member) {
            var fieldInfo = member as FieldInfo;
            if (fieldInfo != null)
            {
                return isMappableType(fieldInfo.FieldType);
            }

            throw new NotImplementedException();
        }

        private bool isMappableType(Type type)
        {
            bool isMappable =
                typeof(string).IsAssignableFrom(type) |
                typeof(Mappable).IsAssignableFrom(type) |
                type.IsPrimitive |
                IsMappableCollection(type);

            return isMappable;
        }

        private bool IsMappableCollection(Type type)
        {
            if (typeof(ICollection).IsAssignableFrom(type))
            {
                Type[] genericArgumentTypes = type.GetGenericArguments();
                if (genericArgumentTypes.Length > 0)
                {
                    var firstArgument = genericArgumentTypes.First();

                    return isMappableType(firstArgument);
                }
            }

            return false;
        }

        private bool isMappable(MemberInfo field)
        {
            var attributes = field.GetCustomAttributes(typeof(NonSerializedAttribute), true);

            bool transientField = (attributes == null || attributes.Length == 0) ? false : true;
            bool instanceField = true;
            bool mappableType = isMappableType(field);
            return !transientField && instanceField && mappableType;
        }

        private List<MemberInfo> getMappableFields()
        {
            List<MemberInfo> fields = new List<MemberInfo>();
            Type c = GetType();
            while (c != null)
            {
                foreach (MemberInfo field in c.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    if (isMappable(field))
                    {
                        fields.Add(field);
                    }
                }
                c = c.BaseType;
            }
            return fields;
        }

        private Object getValue(MemberInfo field) {
            var fieldInfo = field as FieldInfo;
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(this);
            }
            else
            {
                var propertyInfo = field as PropertyInfo;
                if (propertyInfo != null)
                {
                    return propertyInfo.GetValue(this, null);
                }
            }

            throw new NotImplementedException();
        }

        public Dictionary<object, object> toMap()
        {
            Dictionary<Object, Object> map = new Dictionary<Object, Object>();
            List<MemberInfo> mappableFields = getMappableFields();
            foreach (MemberInfo field in mappableFields) {
                Object value;
                value = getValue(field);
                if (value != null && typeof(Mappable).IsAssignableFrom(value.GetType()))
                {
                    value = ((Mappable)value).toMap();
                }
                else
                {
                    if (value != null && typeof(ICollection).IsAssignableFrom(value.GetType()))
                    {
                        List<Object> mappedValue = new List<Object>();
                        foreach (Object o in (ICollection)value)
                        {
                            if (typeof(Mappable).IsAssignableFrom(o.GetType()))
                            {
                                mappedValue.Add(((Mappable)o).toMap());
                            }
                            else
                            {
                                mappedValue.Add(o);
                            }
                        }
                        value = mappedValue;
                    }
                }
                if (value != null && /*!Collections.EMPTY_LIST.equals(value) &&*/ !NO_LINE.Equals(value)) {
                    map[field.Name] = value;
                }
            }
            return map;
        }
    }
}