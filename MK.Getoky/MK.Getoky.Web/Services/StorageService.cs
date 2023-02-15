using System;
using System.Text.Json;
namespace MK.Getoky.Web
{
    /// <summary>
    /// Currently using line-separated text files for storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StorageService<T>
    {
        public StorageService()
        {
        }

        /// <summary>
        /// Assumes a list of items is stored. This is closely coupled to <see cref="SaveItemsAsync(List{T})"/>.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<List<T>> GetItemsAsync()
        {
            string filename = GetFilename(typeof(T));
            Console.WriteLine("Filename:" + filename);

            if (File.Exists(filename))
            {
                string contents = await File.ReadAllTextAsync(filename);
                var retrievedItems = JsonSerializer.Deserialize<List<T>>(contents);
                return retrievedItems!;
            }
            else
            {
                return new List<T>();
            }

        }

        /// <summary>
        /// Automatically generates a single filename based on the data type.
        /// Overwrites existing content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public async Task SaveItemsAsync(List<T> items)
        {
            // todo: read file before saving, incase this new data is stale. But how can you tell what's newer, since it's overwriting all content?
            string filename = GetFilename(typeof(T));
            Console.WriteLine("Saving " + filename + "to " + Path.GetTempPath());
            await File.WriteAllTextAsync(filename, JsonSerializer.Serialize(items));
            Console.WriteLine("Saved " + filename);
        }

        private string GetFilename(Type type)
        {
            // E.g. question-items.json
            return $"{nameof(type)}-Items.json".ToLower();
        }
    }
}

