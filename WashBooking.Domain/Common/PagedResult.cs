using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashBooking.Domain.Common
{
    /// <summary>
    /// Lớp chứa kết quả của một truy vấn được phân trang.
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của các mục.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Danh sách các mục trên trang hiện tại.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Tổng số mục trong toàn bộ tập dữ liệu.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Chỉ số của trang hiện tại (bắt đầu từ 1).
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Kích thước của trang (số mục mỗi trang).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Tổng số trang.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        /// <summary>
        /// Cho biết có trang trước đó hay không.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        /// Cho biết có trang tiếp theo hay không.
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
