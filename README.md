🌐 Multiplayer with Riptide (Client)


🚀 Giới thiệu

Dự án này sử dụng Riptide Networking để xây dựng hệ thống multiplayer trong Unity. Đây là phía Client của hệ thống, chịu trách nhiệm kết nối tới server, nhận và gửi dữ liệu giữa các người chơi.

🛠️ Công nghệ sử dụng

Unity 2023: Công cụ phát triển game.

Riptide Networking: Thư viện giúp tạo kết nối client-server trong môi trường multiplayer.
PlayFab : Giải pháp lưu dữ liệu để làm ứng dụng, game online
C#: Ngôn ngữ lập trình chính.

✨ Các tính năng chính

🌍 Kết nối server: Thiết lập kết nối với server thông qua IP và port.

💬 Gửi và nhận gói tin: Trao đổi dữ liệu với server để xử lý trạng thái và hành động của người chơi.

📍 Đồng bộ vị trí: Cập nhật vị trí của người chơi trên tất cả các client.

👥 Quản lý người chơi: Tạo và quản lý các đối tượng người chơi trong môi trường game.

🗂️ Cấu trúc thư mục

Client/
├── Assets/
│   ├── Scripts/
│   │   ├── Networking/          # Xử lý kết nối và gửi nhận dữ liệu
│   │   ├── Player/              # Điều khiển nhân vật và đồng bộ
│   └── Prefabs/                 # Các đối tượng người chơi và môi trường
├── ProjectSettings/
└── README.md

💻 Hướng dẫn cài đặt

Clone repository về máy:

git clone https://github.com/Anhlearning/Multiplayer-Quantum.git

Mở dự án bằng Unity 2023.

Cài đặt package Riptide Networking từ Unity Package Manager.

Thiết lập địa chỉ IP và cổng trong file cấu hình.

🖥️ Server Side

Phía server của game cũng sử dụng Riptide Networking để quản lý kết nối từ nhiều client, xử lý các gói tin và đồng bộ hóa trạng thái giữa các người chơi.

▶️ Chạy project

Chạy server trước khi khởi động client.

Trong Unity, nhấn nút Play để bắt đầu kết nối và tham gia phòng chơi.

✍️ Tác giả

Đinh Hoàng Anh

Unity Developer
