Hệ thống Quản lý Y tế - PBL3 (đang update)
<div align="center">
<img src="https://img.shields.io/badge/ASP.NET%20Core-6.0-blue" alt="ASP.NET Core 6.0">
<img src="https://img.shields.io/badge/Entity%20Framework%20Core-6.0-green" alt="Entity Framework Core 6.0">
<img src="https://img.shields.io/badge/SQL%20Server-2019-red" alt="SQL Server 2019">
<img src="https://img.shields.io/badge/Bootstrap-5.0-purple" alt="Bootstrap 5.0">
</div>
📋 Tổng quan
Hệ thống quản lý y tế toàn diện hỗ trợ việc quản lý thông tin bệnh nhân, bác sĩ, lịch hẹn khám và hồ sơ y tế. Hệ thống được phân quyền cho nhiều đối tượng sử dụng bao gồm: Admin, Bác sĩ, Bệnh nhân và Nhân viên y tế.
<div align="center">
<table>
<tr>
<td align="center"><b>🧑‍⚕️ Bác sĩ</b></td>
<td align="center"><b>👨‍💼 Admin</b></td>
<td align="center"><b>🏥 Bệnh nhân</b></td>
<td align="center"><b>👩‍⚕️ Nhân viên Y tế</b></td>
</tr>
<tr>
<td>Quản lý lịch khám</td>
<td>Quản lý người dùng</td>
<td>Đặt lịch khám</td>
<td>Quản lý xét nghiệm</td>
</tr>
<tr>
<td>Kê đơn thuốc</td>
<td>Quản lý khoa</td>
<td>Xem hồ sơ y tế</td>
<td>Hỗ trợ bệnh nhân</td>
</tr>
<tr>
<td>Chẩn đoán bệnh</td>
<td>Báo cáo thống kê</td>
<td>Xem đơn thuốc</td>
<td>Nhập liệu y tế</td>
</tr>
</table>
</div>
🏗️ Kiến trúc dự án
Dự án sử dụng kiến trúc N-Layer với Repository Pattern và Service Pattern:
<div align="center">
<img src="https://miro.medium.com/max/1400/16zKYkZLTvTDxN9KpVx0Stw.png" width="600" alt="N-Layer Architecture">
</div>
Presentation Layer: MVC Controllers và Views
Business Logic Layer: Services xử lý logic nghiệp vụ
Data Access Layer: Repositories giao tiếp với Database
Data Layer: Entity Framework Core và SQL Server
## 📁 Cấu trúc thư mục
```plaintext
PBL3/
├── Controllers/                    # Xử lý request từ người dùng
│   ├── AccountController.cs        # Xử lý đăng nhập/đăng ký
│   ├── AdminController.cs          # Quản lý dành cho admin
│   ├── BacSiController.cs          # Quản lý bác sĩ
│   ├── BenhNhanController.cs       # Quản lý bệnh nhân
│   └── LichHenKhamController.cs    # Quản lý lịch hẹn khám
│
├── Models/                         # Định nghĩa các entity
│   ├── BacSi.cs                    # Thông tin bác sĩ
│   ├── BanGhiYTe.cs                # Bản ghi y tế
│   ├── BenhNhan.cs                 # Thông tin bệnh nhân  
│   ├── ChanDoanLamSan.cs           # Chẩn đoán lâm sàng
│   ├── ChiTietDonThuoc.cs          # Chi tiết đơn thuốc
│   ├── DonThuoc.cs                 # Đơn thuốc
│   ├── KetQuaXetNghiem.cs          # Kết quả xét nghiệm
│   ├── Khoa.cs                     # Thông tin khoa
│   ├── LichHenKham.cs              # Thông tin lịch hẹn khám
│   ├── NhanVienYT.cs               # Nhân viên y tế
│   ├── Role.cs                     # Vai trò người dùng
│   ├── Thuoc.cs                    # Thông tin thuốc
│   └── User.cs                     # Thông tin người dùng
│
├── Views/                          # Giao diện người dùng
│   ├── Account/                    # Đăng nhập/đăng ký
│   ├── Admin/                      # Giao diện quản trị viên
│   ├── BacSi/                      # Giao diện bác sĩ
│   ├── BenhNhan/                   # Giao diện bệnh nhân
│   ├── LichHenKham/                # Quản lý lịch hẹn
│   ├── Shared/                     # Layout và partial views
│   │   ├── _Layout.cshtml          # Layout chính
│   │   └── _LoginPartial.cshtml    # Partial view đăng nhập
│   └── Home/                       # Trang chủ
│
├── Data/                           # Truy cập dữ liệu
│   └── ApplicationDbContext.cs     # DbContext cho Entity Framework
│
├── Repositories/                   # Truy vấn database
│   ├── Implementations/            # Triển khai repository
│   │   ├── GenericRepository.cs    # Repository generic
│   │   └── UnitOfWork.cs           # Unit of Work pattern
│   └── Interfaces/                 # Định nghĩa interface
│       ├── IGenericRepository.cs   # Interface repository generic
│       └── IUnitOfWork.cs          # Interface Unit of Work
│
├── Services/                       # Xử lý nghiệp vụ
│   ├── Interfaces/                 # Định nghĩa interface service
│   │   ├── IAuthService.cs         # Service xác thực
│   │   └── ILichHenKhamService.cs  # Service quản lý lịch hẹn
│   └── Implementations/            # Triển khai service
│       ├── AuthService.cs          # Triển khai xác thực
│       └── LichHenKhamService.cs   # Triển khai quản lý lịch hẹn
│
├── Helpers/                        # Các lớp hỗ trợ
│   └── PasswordHasher.cs           # Mã hóa mật khẩu
│
├── Migrations/                     # EF Core Migrations
│   └── [Timestamp]_InitialCreate.cs
│
├── wwwroot/                        # Static files
│   ├── css/                        # Stylesheets
│   ├── js/                         # JavaScript
│   └── images/                     # Hình ảnh
│
├── Program.cs                      # Entry point
└── appsettings.json                # Cấu hình ứng dụng
```
✨ Chức năng chính
<div align="center">
<table>
<tr>
<th>Chức năng</th>
<th>Mô tả</th>
</tr>
<tr>
<td><b>🔐 Đăng nhập/Phân quyền</b></td>
<td>Xác thực người dùng bằng Cookie Authentication và phân quyền dựa trên Role</td>
</tr>
<tr>
<td><b>👨‍⚕️ Quản lý bác sĩ</b></td>
<td>Quản lý thông tin bác sĩ, phân công vào khoa, phòng khám</td>
</tr>
<tr>
<td><b>🏥 Quản lý bệnh nhân</b></td>
<td>Quản lý hồ sơ bệnh nhân, lịch sử khám bệnh</td>
</tr>
<tr>
<td><b>📅 Đặt lịch khám</b></td>
<td>Bệnh nhân đặt lịch với bác sĩ theo thời gian mong muốn</td>
</tr>
<tr>
<td><b>📝 Bản ghi y tế</b></td>
<td>Lưu trữ thông tin khám bệnh, chẩn đoán và kết quả điều trị</td>
</tr>
<tr>
<td><b>💊 Kê đơn thuốc</b></td>
<td>Bác sĩ kê đơn thuốc với chi tiết liều lượng, cách dùng</td>
</tr>
<tr>
<td><b>🔬 Quản lý xét nghiệm</b></td>
<td>Nhập và theo dõi kết quả xét nghiệm của bệnh nhân</td>
</tr>
<tr>
<td><b>📊 Báo cáo thống kê</b></td>
<td>Xem báo cáo về số lượng bệnh nhân, lịch hẹn, doanh thu</td>
</tr>
</table>
</div>
🛠️ Công nghệ sử dụng
Backend:
ASP.NET Core MVC 9.0
Entity Framework Core 9.0.3
SQL Server 2019
Repository Pattern
Unit of Work Pattern
Cookie-based Authentication
Frontend:
Razor Views
HTML5, CSS3, JavaScript
Bootstrap 5.0
jQuery
🚀 Cài đặt và chạy
Yêu cầu hệ thống
.NET 6.0 SDK
SQL Server 2019
Visual Studio 2022 (Khuyến nghị)
Các bước cài đặt
1. Clone repository:
   git clone https://github.com/yourusername/PBL3.git
   cd PBL3
2. Cấu hình connection string:
Mở file appsettings.json và cập nhật connection string:
    "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=PBL3;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
3. Chạy migration để tạo database:
    dotnet ef database update
4. Khởi chạy:
    dotnet run
5. Truy cập ứng dụng: Mở trình duyệt và truy cập https://localhost:7136
📜 License
Copyright © 2024 - PBL3 Team
🤝 Nhóm phát triển
Vương Phạm Ngọc Huy
Nguyễn Thị Thùy Linh
<div align="center">
<p>Phát triển bởi Nhóm PBL3 - 2025</p>
</div>