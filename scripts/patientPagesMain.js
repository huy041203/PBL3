window.onload = function () {
  // Chèn header vào trang
  fetch('components/header.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('header-container').innerHTML = data;
    });

    // Chèn patientNav vào trang
    fetch('components/patientNav.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('patient-nav-container').innerHTML = data;

      // Gắn sự kiện click cho nav sau khi đã load xong nav
      setupPatientNavEvents();
    });

  // Load mặc định contentProfile
  fetch('patientpages/patientProfile.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('patient-content-container').innerHTML = data;
    });
 
    function setupPatientNavEvents() {
      const nav = document.getElementById('patient-nav-container');
      if (!nav) return;
    
      nav.addEventListener('click', function (e) {
        const link = e.target.closest('a.patient-nav__link');
        if (!link) return;
    
        e.preventDefault(); // Ngăn trình duyệt nhảy lên đầu trang
    
        const page = link.getAttribute('data-page');
    
        let pageFile = '';
        switch (page) {
          case 'profile':
            pageFile = 'patientpages/patientProfile.html';
            break;
          case 'appointment':
            pageFile = 'patientpages/appointment.html';
            break;
          case 'help':
            pageFile = 'patientpages/patientHelp.html';
            break;
          case 'paymentAfter':
            pageFile = 'patientpages/paymentAfter.html';
              fetch(pageFile)
                .then(res => res.text())
                .then(html => {
                  document.getElementById('patient-content-container').innerHTML = html;
            
                  // Gắn sự kiện mở modal SAU khi HTML đã được chèn xong
                  setupPaymentModalEvents();
                });
              return; // Không chạy tiếp fetch phía dưới
          
          default:
            pageFile = 'patientpages/patientProfile.html';
        }
    
        fetch(pageFile)
          .then(res => res.text())
          .then(html => {
            document.getElementById('patient-content-container').innerHTML = html;
          });
      });
    }
    
    function setupPaymentModalEvents() {
      // Lấy phần tử "Chưa thanh toán"
      const unpaidStatus = document.getElementById("unpaid");
      
      // Nếu có modal sẵn trong DOM
      let modal = document.querySelector(".payment-modal");
      
      // Nếu không có modal sẵn, cần tải từ file paymentGeneral.html
      if (!modal && unpaidStatus) {
        fetch('patientpages/paymentGeneral.html')
          .then(response => response.text())
          .then(data => {
            // Thêm modal vào trang
            const tempDiv = document.createElement('div');
            tempDiv.innerHTML = data;
            
            // Lấy modal từ nội dung đã tải
            modal = tempDiv.querySelector('.payment-modal');
            
            if (modal) {
              // Thêm modal vào trang
              document.body.appendChild(modal);
              
              // Thêm thuộc tính id
              modal.id = "payment-modal";
              
              // Gắn sự kiện cho nút đóng modal
              const closeModalBtn = modal.querySelector(".payment-modal__close");
              if (closeModalBtn) {
                closeModalBtn.addEventListener("click", function() {
                  modal.classList.remove("modal--show");
                });
              }
              
              // Gắn sự kiện click bên ngoài modal để đóng
              modal.addEventListener("click", function(e) {
                if (e.target === modal) {
                  modal.classList.remove("modal--show");
                }
              });
              
              // Gắn sự kiện cho nút "Chưa thanh toán"
              unpaidStatus.addEventListener("click", function() {
                modal.classList.add("modal--show");
              });
            }
          })
          .catch(error => {
            console.error('Lỗi khi tải modal thanh toán:', error);
          });
      } else if (unpaidStatus && modal) {
        // Nếu đã có cả modal và nút "Chưa thanh toán", thì chỉ cần gắn sự kiện
        
        // Gắn sự kiện cho nút "Chưa thanh toán"
        unpaidStatus.addEventListener("click", function() {
          modal.classList.add("modal--show");
        });
        
        // Gắn sự kiện cho nút đóng modal
        const closeModalBtn = modal.querySelector(".payment-modal__close");
        if (closeModalBtn) {
          closeModalBtn.addEventListener("click", function() {
            modal.classList.remove("modal--show");
          });
        }
        
        // Gắn sự kiện click bên ngoài modal để đóng
        modal.addEventListener("click", function(e) {
          if (e.target === modal) {
            modal.classList.remove("modal--show");
          }
        });
      }
    }
    

  fetch('components/footer.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('footer-container').innerHTML = data;
      // Khởi tạo hiệu ứng cho services__detail SAU KHI nội dung đã được tải
      initializeServicesDetailAnimation();

      // Gắn sự kiện click sau khi nội dung đã được tải
      setupSmoothScroll();

      // Gắn sự kiện cho các dịch vụ sau khi nội dung đã được tải
      setupServicesItems();

      // Cập nhật active menu
  
    });
    
};

