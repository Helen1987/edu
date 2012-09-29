using System;
using System.Reflection;

namespace DynamicGenerics
{
    /// <summary>
    /// A delegate which can reference the ObjectCreator.Create method.
    /// </summary>
    delegate T CreatorDelegate<T>();

    /// <summary>
    /// Creates object of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of object to create.</typeparam>
    class ObjectCreator<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    /// <summary>
    /// Demonstrates how a generic type and a generic delegate can be bound to at runtime
    /// using types obtained with Reflection.  The focus of this sample is on the MakeGenericType
    /// method, which constructs a closed generic type from an open generic type.
    /// </summary>
    class GenericsAtRuntime
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a type name from mscorlib (including namespace): ");
            string typeName = Console.ReadLine();
            Type type = Type.GetType(typeName);

            //Create the type of ObjectCreator<> that we need and make an instance of it
            Type objectCreatorType = typeof(ObjectCreator<>).MakeGenericType(type);
            object objectCreator = Activator.CreateInstance(objectCreatorType);

            //Create the type of CreatorDelegate<> that we need
            Type creatorDelegateType = typeof(CreatorDelegate<>).MakeGenericType(type);

            MethodInfo createMethod = objectCreatorType.GetMethod("Create");

            //Create the creator delegate, note that we can't bind to CreatorDelegate<>
            //statically because it's an open generic type
            Delegate creatorDelegate = Delegate.CreateDelegate(creatorDelegateType, objectCreator, createMethod);
            
            //Invoke the delegate to get an instance
            object instance = creatorDelegate.DynamicInvoke();

            Console.WriteLine(instance);
        }
    }
}
