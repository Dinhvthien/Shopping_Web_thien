using Newtonsoft.Json;
using Shopping_Web_thien.Models;
namespace Shopping_Website.Services
{
	public static class SissionServices
	{
		// Lấy dữ liệu từ session trả về 1 list sản phẩm
		public static List<Product> GetObjFromSession(ISession session, string key)
		{
			// Bước 1: Lấy string data từ session ở dạng json
			string jsonData = session.GetString(key);
			if (jsonData == null) return new List<Product>();
			// Nếu dữ liệu null thì tạo mới 1 list rỗng
			// bước 2: Convert về List
			var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
			return products;
		}
		// Ghi dữ liệu từ 1 list vào session
		public static void SetObjToSession(ISession session, string key, object values)
		{
			var jsonData = JsonConvert.SerializeObject(values);
			session.SetString(key, jsonData);
		}
		public static bool CheckExistProduct(Guid id, List<Product> products)
		{
			return products.Any(x => x.Id == id);
		}
		// Kiểm tra sự tồn tại của sp trong List
	}
}
