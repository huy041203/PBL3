window.onload = function () {
  // Chèn header vào trang
  fetch('components/header.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('header-container').innerHTML = data;
    });

    loadHomePage();

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



// Hàm để tải trang chủ
function loadHomePage(){
  // Chèn nội dung chính vào trang và khởi tạo hiệu ứng sau khi nội dung đã được tải
  return fetch('homepages/home.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('content-container').innerHTML = data;

      // Khởi tạo hiệu ứng cho services__detail SAU KHI nội dung đã được tải
      initializeServicesDetailAnimation();

      // Gắn sự kiện click sau khi nội dung đã được tải
      setupSmoothScroll();

      // Gắn sự kiện cho các dịch vụ sau khi nội dung đã được tải
      setupServicesItems();
    });
}

// Hàm để tải trang đặt lịch
function loadBookingPage() {
  window.scrollTo({ top: 0, behavior: "auto" }); // Tránh bị giật vì scroll
  return fetch('homepages/booking.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('content-container').innerHTML = data;

      // Click Đặt lịch hẹn Detail
      const doctorDetails = document.querySelectorAll('.booking .doctor-card__button');
      doctorDetails.forEach((item) => {
        item.addEventListener("click", (event) => {
          event.preventDefault();
          loadBookingDetailPage().then(() => {
            smoothScrollTo('.booking-detail');
          });
        });
      });

      // Nếu trang booking có các hàm khởi tạo riêng, bạn có thể gọi chúng ở đây
      // Ví dụ: initializeBookingForm();
    });
}

function loadLogin(){
  return fetch('homepages/login.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('content-container').innerHTML = data;
    });
}

function loadRegister(){
  return fetch('homepages/register.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('content-container').innerHTML = data;
    });
}

function loadBookingDetailPage() {
  window.scrollTo({ top: 0, behavior: "auto" }); // Tránh bị giật vì scroll
  return fetch('homepages/booking_detail.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('content-container').innerHTML = data;
      
      // thoat ra 
      const out = document.querySelector('.nav__home-svg');
      if (out) {
        out.addEventListener("click", (event) => {
          event.preventDefault();
          loadBookingPage().then(() => {
            smoothScrollTo('.booking');
          });
        });
      }
      
      // Nếu trang booking có các hàm khởi tạo riêng, bạn có thể gọi chúng ở đây
      // Ví dụ: initializeBookingForm();
    });
}




// Hàm thiết lập sự kiện cho các mục dịch vụ
function setupServicesItems() {
  // Lấy tất cả các items dịch vụ
  const serviceItems = document.querySelectorAll('.services__item');

  // Lấy chiều cao của header cố định
  const headerHeight = document.querySelector('.header').offsetHeight + 95;

  // Hàm cuộn mượt đến phần tử
  function smoothScrollTo(target) {
    const targetPosition = target.getBoundingClientRect().top + window.pageYOffset - headerHeight;
    window.scrollTo({
      top: targetPosition,
      behavior: "smooth",
    });
  }

  // Gắn sự kiện click cho từng dịch vụ
  serviceItems.forEach((item) => {
    item.addEventListener('click', (event) => {
      event.preventDefault();

      // Lấy ID của item được click
      const itemId = item.id;
      console.log("Đã nhấn vào " + itemId);

      // Xác định phần detail tương ứng với item
      let detailId;

      if (itemId === 'services__item-1') {
        detailId = 'services__detail-1';
      } else if (itemId === 'services__item-2') {
        detailId = 'services__detail-2';
      } else if (itemId === 'services__item-3') {
        detailId = 'services__detail-3';
      } else if (itemId === 'services__item-4') {
        detailId = 'services__detail-4';
      }
      else {
        // Nếu không có ID cụ thể, mặc định cuộn đến phần .services__detail
        const servicesDetail = document.querySelector('.services__detail');
        if (servicesDetail) {
          smoothScrollTo(servicesDetail);
        }
        return;
      }

      // Tìm phần tử detail tương ứng và cuộn đến đó
      const detailSection = document.getElementById(detailId);
      if (detailSection) {
        smoothScrollTo(detailSection);
      } else {
        console.log(`Không tìm thấy phần tử có id ${detailId}`);
        // Nếu không tìm thấy phần tử cụ thể, cuộn đến phần .services__detail
        const servicesDetail = document.querySelector('.services__detail');
        if (servicesDetail) {
          smoothScrollTo(servicesDetail);
        }
      }
    });
  });

  // Xử lý riêng cho item "Xét nghiệm" (để bảo đảm tương thích với code cũ)
  const services1Link = document.querySelector('#services__item-1');
  const services1Section = document.querySelector('#services__detail-1');
  if (services1Link && services1Section) {
    services1Link.addEventListener("click", (event) => {
      console.log("Đã nhấn vào services__item-1");
      event.preventDefault();
      smoothScrollTo(services1Section);
    });
  }

  // Xử lý riêng cho item "Chuẩn đoán"
  const services2Link = document.querySelector('#services__item-2');
  const services2Section = document.querySelector('.services__detail-2');
  if (services2Link && services2Section) {
    services2Link.addEventListener("click", (event) => {
      console.log("Đã nhấn vào services__item--2");
      event.preventDefault();
      smoothScrollTo(services2Section);
    });
  }

  // Xử lý riêng cho item "Tư vấn sức khỏe"
  const services3Link = document.querySelector('#services__item-3');
  const services3Section = document.querySelector('.services__detail-3');
  if (services3Link && services3Section) {
    services3Link.addEventListener("click", (event) => {
      console.log("Đã nhấn vào services__item--3");
      event.preventDefault();
      smoothScrollTo(services3Section);
    });
  }

  // Xử lý riêng cho item khám chuyên khoa 
  const services4Link = document.querySelector('#services__item-4');
  const services4Section = document.querySelector('#chuyenkhoa');
  if (services4Link && services4Section) {
    services4Link.addEventListener("click", (event) => {
      console.log("Đã nhấn vào services__item--4");
      event.preventDefault();
      smoothScrollTo(services4Section);
    });
  }
}

// Hàm khởi tạo hiệu ứng cuộn mượt của nav header
function setupSmoothScroll() {
  const headerHeight = document.querySelector('.header').offsetHeight + 10;

  function smoothScrollTo(targetSelector) {
    const checkAndScroll = () => {
      const target = document.querySelector(targetSelector);
      if (target) {
        const targetPosition = target.getBoundingClientRect().top + window.pageYOffset - headerHeight;
        window.scrollTo({
          top: targetPosition,
          behavior: "smooth",
        });
        return true;
      }
      return false;
    };

    // Nếu phần tử đã có trong DOM, cuộn ngay
    if (!checkAndScroll()) {
      // Nếu chưa có, thử đợi vài mili giây rồi thử lại
      const interval = setInterval(() => {
        if (checkAndScroll()) {
          clearInterval(interval);
        }
      }, 100); // kiểm tra mỗi 100ms
    }
  }

  // Click Trang chủ
  const homeLink = document.querySelector('.header__item.trangchu a');
  if (homeLink) {
    homeLink.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('.slider');
      });
    });
  }

  // Click Dịch vụ
  const servicesLink = document.querySelector('.header__item.dichvu a');
  if (servicesLink) {
    servicesLink.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('.services');
      });
    });
  }

  // Click Chuyên khoa
  const chuyenkhoaLink = document.querySelector('.header__item.chuyenkhoa a');
  if (chuyenkhoaLink) {
    chuyenkhoaLink.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('#chuyenkhoa');
      });
    });
  }
  // Click Chuyên khoa detail 
  const chuyenkhoaDetails = document.querySelectorAll('#chuyenkhoa .services__item');
  chuyenkhoaDetails.forEach((item) => {
    item.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('#topbacsi');
      });
    });
  });

  // Click Top bác sĩ
  const topbacsiLink = document.querySelector('.header__item.topbacsi a');
  if (topbacsiLink) {
    topbacsiLink.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('#topbacsi');
      });
    });
  }


  // Click Đặt lịch hẹn
  // Gộp cả link và button vào một mảng
  const bookingTriggers = [
    document.querySelector('.header__item.datlichhen a'),
    document.querySelector('.slider__button'),
    document.querySelector('.services__detail-button'),
  ];
  // Gắn cùng một xử lý cho tất cả
  bookingTriggers.forEach(trigger => {
    if (trigger) {
      trigger.addEventListener("click", (event) => {
        event.preventDefault();
        loadBookingPage().then(() => {
          smoothScrollTo('.booking');
        });
      });
    }
  });

  // Click Liên hệ (footer)
  const footertLink = document.querySelector('.header__item.lienhe a');
  if (footertLink) {
    footertLink.addEventListener("click", (event) => {
      event.preventDefault();
        smoothScrollTo('#footer');
    });
  }

  // Click Đặt lịch hẹn Detail
  const datlichDetails = document.querySelectorAll('.doctors__button');
  datlichDetails.forEach((item) => {
    item.addEventListener("click", (event) => {
      event.preventDefault();
      loadBookingDetailPage().then(() => {
        smoothScrollTo('.booking-detail');
      });
    });
  });


  
// Click Đăng nhập
const loginBtn = document.getElementById('login-btn');
if (loginBtn) {
  loginBtn.addEventListener("click", (event) => {
    event.preventDefault();
    loadLogin().then(() => {
      setupLoginModal();
    });
  });
}


// Hàm thiết lập modal đăng nhập
function setupLoginModal() {
  const modalLogin = document.querySelector('.modal');
  
  // Xóa tất cả event listener cũ (nếu có) bằng cách sử dụng clone
  const newModalLogin = modalLogin.cloneNode(true);
  if (modalLogin.parentNode) {
    modalLogin.parentNode.replaceChild(newModalLogin, modalLogin);
  }
  
  // Hiển thị modal với hiệu ứng fade in
  newModalLogin.style.opacity = '0';
  newModalLogin.classList.add('open');
  setTimeout(() => {
    newModalLogin.style.transition = 'opacity 0.1s ease';
    newModalLogin.style.opacity = '1';
  }, 10);

  // Xử lý click bên ngoài container để đóng modal
  newModalLogin.addEventListener('click', (e) => {
    const modalContainerLogin = document.querySelector('.login__container');
    if (modalContainerLogin && !modalContainerLogin.contains(e.target)) {
      closeModalWithAnimation(newModalLogin, () => {
        loadHomePage();
      });
    }
  });

  // Xử lý nút chuyển đến trang đăng ký
  const goToRegister = document.getElementById('go-to-register');
  if (goToRegister) {
    goToRegister.addEventListener('click', (e) => {
      e.preventDefault();
      e.stopPropagation();
      
      // Thêm hiệu ứng chuyển đổi
      const modalContainerLogin = document.querySelector('.login__container');
      if (modalContainerLogin) {
        // Hiệu ứng trượt ra
        modalContainerLogin.style.transition = 'transform 0.1s ease, opacity 0.1s ease';
        modalContainerLogin.style.transform = 'translateX(-50px)';
        modalContainerLogin.style.opacity = '0';
        
        setTimeout(() => {
          closeModalWithAnimation(newModalLogin, () => {
            loadRegister().then(() => {
              setupRegisterModal();
            });
          });
        }, 300);
      }
    });
  }
}

// Hàm thiết lập modal đăng ký
function setupRegisterModal() {
  const modalRegister = document.querySelector('.modal');
  
  // Xóa tất cả event listener cũ (nếu có) bằng cách sử dụng clone
  const newModalRegister = modalRegister.cloneNode(true);
  if (modalRegister.parentNode) {
    modalRegister.parentNode.replaceChild(newModalRegister, modalRegister);
  }
  
  // Hiển thị modal với hiệu ứng fade in
  newModalRegister.style.opacity = '0.5';
  newModalRegister.classList.add('open');
  
  // Hiệu ứng trượt vào
  const modalContainerRegister = document.querySelector('.register__container');
  if (modalContainerRegister) {
    modalContainerRegister.style.transform = 'translateX(50px)';
    modalContainerRegister.style.opacity = '0';
    modalContainerRegister.style.transition = 'transform 0.1s ease, opacity 0.1s ease';
    
    setTimeout(() => {
      newModalRegister.style.transition = 'opacity 0.1s ease';
      newModalRegister.style.opacity = '1';
      modalContainerRegister.style.transform = 'translateX(0)';
      modalContainerRegister.style.opacity = '1';
    }, 10);
  } else {
    setTimeout(() => {
      newModalRegister.style.transition = 'opacity 0.1s ease';
      newModalRegister.style.opacity = '1';
    }, 10);
  }

  // Xử lý click bên ngoài container để đóng modal
  newModalRegister.addEventListener('click', (e) => {
    const modalContainerRegister = document.querySelector('.register__container');
    if (modalContainerRegister && !modalContainerRegister.contains(e.target)) {
      closeModalWithAnimation(newModalRegister, () => {
        loadHomePage();
      });
    }
  });

  // Xử lý nút quay lại trang đăng nhập
  const backToLogin = document.getElementById('back-to-login');
  if (backToLogin) {
    backToLogin.addEventListener('click', (e) => {
      e.preventDefault();
      e.stopPropagation();
      
      // Thêm hiệu ứng chuyển đổi
      const modalContainerRegister = document.querySelector('.register__container');
      if (modalContainerRegister) {
        // Hiệu ứng trượt ra
        modalContainerRegister.style.transition = 'transform 0.3s ease, opacity 0.3s ease';
        modalContainerRegister.style.transform = 'translateX(50px)';
        modalContainerRegister.style.opacity = '0';
        
        setTimeout(() => {
          closeModalWithAnimation(newModalRegister, () => {
            loadLogin().then(() => {
              setupLoginModal();
            });
          });
        }, 300);
      }
    });
  }
}

// Hàm đóng modal với hiệu ứng fade out
function closeModalWithAnimation(modal, callback) {
  modal.style.transition = 'opacity 0.1s ease';
  modal.style.opacity = '0';
  
  setTimeout(() => {
    modal.classList.remove('open');
    if (callback) callback();
  }, 300);
}

// // Hàm thiết lập modal đăng nhập
// function setupLoginModal() {
//   const modalLogin = document.querySelector('.modal');
  
//   // Xóa tất cả event listener cũ (nếu có) bằng cách sử dụng clone
//   const newModalLogin = modalLogin.cloneNode(true);
//   if (modalLogin.parentNode) {
//     modalLogin.parentNode.replaceChild(newModalLogin, modalLogin);
//   }
  
//   // Hiển thị modal với hiệu ứng fade in
//   newModalLogin.style.opacity = '0';
//   newModalLogin.classList.add('open');
//   setTimeout(() => {
//     newModalLogin.style.transition = 'opacity 0.1s ease';
//     newModalLogin.style.opacity = '1';
//   }, 10);

//   // Xử lý click bên ngoài container để đóng modal
//   newModalLogin.addEventListener('click', (e) => {
//     const modalContainerLogin = document.querySelector('.login__container');
//     if (modalContainerLogin && !modalContainerLogin.contains(e.target)) {
//       closeModalWithAnimation(newModalLogin, () => {
//         loadHomePage();
//       });
//     }
//   });

//   // Xử lý nút chuyển đến trang đăng ký
//   const goToRegister = document.getElementById('go-to-register');
//   if (goToRegister) {
//     goToRegister.addEventListener('click', (e) => {
//       e.preventDefault();
//       e.stopPropagation();
      
//       // Thêm hiệu ứng chuyển đổi
//       const modalContainerLogin = document.querySelector('.login__container');
//       if (modalContainerLogin) {
//         // Hiệu ứng trượt ra
//         modalContainerLogin.style.transition = 'transform 0.1s ease, opacity 0.1s ease';
//         modalContainerLogin.style.transform = 'translateX(-50px)';
//         modalContainerLogin.style.opacity = '0';
        
//         setTimeout(() => {
//           closeModalWithAnimation(newModalLogin, () => {
//             loadRegister().then(() => {
//               setupRegisterModal();
//             });
//           });
//         }, 300);
//       }
//     });
//   }
// }

// // Hàm thiết lập modal đăng ký
// function setupRegisterModal() {
//   const modalRegister = document.querySelector('.modal');
  
//   // Xóa tất cả event listener cũ (nếu có) bằng cách sử dụng clone
//   const newModalRegister = modalRegister.cloneNode(true);
//   if (modalRegister.parentNode) {
//     modalRegister.parentNode.replaceChild(newModalRegister, modalRegister);
//   }
  
//   // Hiển thị modal với hiệu ứng fade in
//   newModalRegister.style.opacity = '0.5';
//   newModalRegister.classList.add('open');
  
//   // Hiệu ứng trượt vào
//   const modalContainerRegister = document.querySelector('.register__container');
//   if (modalContainerRegister) {
//     modalContainerRegister.style.transform = 'translateX(50px)';
//     modalContainerRegister.style.opacity = '0';
//     modalContainerRegister.style.transition = 'transform 0.1s ease, opacity 0.1s ease';
    
//     setTimeout(() => {
//       newModalRegister.style.transition = 'opacity 0.1s ease';
//       newModalRegister.style.opacity = '1';
//       modalContainerRegister.style.transform = 'translateX(0)';
//       modalContainerRegister.style.opacity = '1';
//     }, 10);
//   } else {
//     setTimeout(() => {
//       newModalRegister.style.transition = 'opacity 0.1s ease';
//       newModalRegister.style.opacity = '1';
//     }, 10);
//   }

//   // Xử lý click bên ngoài container để đóng modal
//   newModalRegister.addEventListener('click', (e) => {
//     const modalContainerRegister = document.querySelector('.register__container');
//     if (modalContainerRegister && !modalContainerRegister.contains(e.target)) {
//       closeModalWithAnimation(newModalRegister, () => {
//         loadHomePage();
//       });
//     }
//   });

//   // Xử lý nút quay lại trang đăng nhập
//   const backToLogin = document.getElementById('back-to-login');
//   if (backToLogin) {
//     backToLogin.addEventListener('click', (e) => {
//       e.preventDefault();
//       e.stopPropagation();
      
//       // Thêm hiệu ứng chuyển đổi
//       const modalContainerRegister = document.querySelector('.register__container');
//       if (modalContainerRegister) {
//         // Hiệu ứng trượt ra
//         modalContainerRegister.style.transition = 'transform 0.3s ease, opacity 0.3s ease';
//         modalContainerRegister.style.transform = 'translateX(50px)';
//         modalContainerRegister.style.opacity = '0';
        
//         setTimeout(() => {
//           closeModalWithAnimation(newModalRegister, () => {
//             loadLogin().then(() => {
//               setupLoginModal();
//             });
//           });
//         }, 300);
//       }
//     });
//   }
// }

// // Hàm đóng modal với hiệu ứng fade out
// function closeModalWithAnimation(modal, callback) {
//   modal.style.transition = 'opacity 0.1s ease';
//   modal.style.opacity = '0';
  
//   setTimeout(() => {
//     modal.classList.remove('open');
//     if (callback) callback();
//   }, 300);
// }

// Loại bỏ phần code trùng lặp ở cuối
// Đoạn code này đã được tích hợp vào logic xử lý phía trên

  // Tìm hiểu thêm từ slider
  const timhieuLink = document.querySelector('.slider__description a');
  if (timhieuLink) {
    timhieuLink.addEventListener("click", (event) => {
      event.preventDefault();
      loadHomePage().then(() => {
        smoothScrollTo('.services');
      });
    });
  }
}






// Hiệu ứng cho slider image biến mất khi scroll 
document.addEventListener("scroll", () => {
  const sliderImage = document.querySelector(".slider__image img");
  if (sliderImage) {
    if (window.scrollY > 200) {
      sliderImage.classList.add("hidden");
    } else {
      sliderImage.classList.remove("hidden");
    }
  }
});




// Hàm khởi tạo hiệu ứng cho decoration services__detail
function initializeServicesDetailAnimation() {
  console.log("Bắt đầu khởi tạo hiệu ứng cho services__detail");

  const servicesDetail = document.querySelector(".services__detail");
  const decorations = document.querySelectorAll(
    ".services__detail-decoration--4, .services__detail-decoration--5"
  );

  if (!servicesDetail) {
    console.error("Không tìm thấy phần tử .services__detail");
    return;
  }

  console.log("Đã tìm thấy phần tử .services__detail");
  console.log("Số lượng phần tử trang trí:", decorations.length);

  // Hàm kiểm tra phần tử có trong viewport không
  function isElementInViewport(el) {
    const rect = el.getBoundingClientRect();
    return (
      rect.top <= window.innerHeight &&
      rect.bottom >= 0
    );
  }

  // Hàm kiểm tra và thêm/xóa class visible
  function checkVisibility() {
    if (isElementInViewport(servicesDetail)) {
      console.log("Phần tử services__detail đang trong viewport");
      decorations.forEach(decoration => {
        decoration.classList.add("visible");
      });
    } else {
      console.log("Phần tử services__detail không trong viewport");
      decorations.forEach(decoration => {
        decoration.classList.remove("visible");
      });
    }
  }

  // Kiểm tra ngay khi khởi tạo
  checkVisibility();

  // Kiểm tra khi cuộn trang
  window.addEventListener("scroll", checkVisibility);
}


