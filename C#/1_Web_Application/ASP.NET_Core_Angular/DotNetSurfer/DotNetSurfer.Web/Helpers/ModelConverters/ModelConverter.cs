using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetSurfer.Web.Helpers.ModelConverters
{
    public static class ModelConverter
    {
        private static Func<object, object> convertBase64ToBinary = (s) => Convert.FromBase64String(s as string);
        private static Func<object, object> convertBinaryToBase64 = (s) => Convert.ToBase64String(s as byte[]);

        public static object ConvertBinaryModelsToBase64Models(object binaryModel, Type base64ModelType, List<string> targetPropertyNames)
        {
            var base64Model = ConvertFromModelToModel(binaryModel, base64ModelType, targetPropertyNames, convertBinaryToBase64);

            return base64Model;
        }

        public static Array ConvertBinaryModelsToBase64Models(object[] binaryModels, Type base64ModelType, List<string> targetPropertyNames)
        {
            int length = binaryModels?.Length ?? 0;
            var base64Models = Array.CreateInstance(base64ModelType, length); // model to convert

            for (int i = 0; i < length; i++)
            {
                var base64Model = ConvertFromModelToModel(binaryModels[i], base64ModelType, targetPropertyNames, convertBinaryToBase64);
                base64Models.SetValue(base64Model, i);
            }

            return base64Models;
        }

        public static object ConvertBase64ModelsToBinaryModels(object base64Model, Type binaryModelType, List<string> targetPropertyNames)
        {
            var binaryModel = ConvertFromModelToModel(base64Model, binaryModelType, targetPropertyNames, convertBase64ToBinary);

            return binaryModel;
        }

        public static Array ConvertBase64ModelsToBinaryModels(object[] base64Models, Type binaryModelType, List<string> targetPropertyNames)
        {
            int length = base64Models?.Length ?? 0;
            var binaryModels = Array.CreateInstance(binaryModelType, length); // model to convert

            for (int i = 0; i < length; i++)
            {
                var binaryModel = ConvertFromModelToModel(base64Models[i], binaryModelType, targetPropertyNames, convertBase64ToBinary);
                binaryModels.SetValue(binaryModel, i);
            }

            return binaryModels;
        }

        private static object ConvertFromModelToModel(object fromModel, Type toModelType, List<string> targetPropertyNames, Func<object, object> convertFunc)
        {
            var propertyDic = new Dictionary<string, object>(); // Key: PropertyName, Value: PropertyValue

            // Store fromModel values
            var fromModelProperties = fromModel?.GetType().GetProperties();
            foreach (var property in fromModelProperties ?? Enumerable.Empty<PropertyInfo>())
            {
                string name = property.Name;
                var value = property.GetValue(fromModel);
                if (value == null) // to avoid unnecessary mapping
                    continue;

                propertyDic.Add(name, value);
            }

            // Map from fromModel to toModel
            var toModel = Activator.CreateInstance(toModelType);
            var toModelProperties = toModelType.GetProperties();
            foreach (var property in toModelProperties)
            {
                string name = property.Name;
                if (!propertyDic.ContainsKey(name)) // to avoid unnecessary mapping
                    continue;

                var value = (targetPropertyNames?.Contains(name) ?? false) // target object case check
                    ? convertFunc(propertyDic[name]) // converted value
                    : propertyDic[name];
                property.SetValue(toModel, value);
            }

            return toModel;
        }
    }
}
