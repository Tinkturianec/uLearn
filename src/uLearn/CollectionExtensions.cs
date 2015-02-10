using System;
using System.Collections.Generic;

namespace uLearn
{
	public static class CollectionExtensions
	{
		public static TOutput Call<TInput, TOutput>(this TInput input, Func<TInput, TOutput> f)
			where TInput : class
			where TOutput : class
		{
			return input == null ? null : f(input);
		}

		public static TOutput Call<TInput, TOutput>(this TInput input, Func<TInput, TOutput> f, TOutput defaultValue)
			where TInput : class
		{
			return input == null ? defaultValue : f(input);
		}

		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
		{
			TValue v;
			if (dictionary.TryGetValue(key, out v)) return v;
			throw new KeyNotFoundException("Key " + key + " not found in dictionary");
		}

		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			TValue v;
			if (dictionary.TryGetValue(key, out v)) return v;
			return defaultValue;
		}

		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
		{
			TValue v;
			dictionary.TryGetValue(key, out v);
			return v;
		}
	}
}