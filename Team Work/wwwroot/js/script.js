let loginForm = document.querySelector(".login-form");
let registerForm = document.querySelector(".register-form");
let loginBtn = document.querySelector(".login-btn");
let registerBtn = document.querySelector(".register-btn");
let registerSubmitBtn = document.querySelector(".register-submit");
let loginSubmitBtn = document.querySelector(".login-submit");
let btnsEffect = document.querySelector(".btns-effect");
registerSubmitBtn.addEventListener("click", (e) => {
    e.preventDefault()
})
loginSubmitBtn.addEventListener("click", (e) => {
    e.preventDefault()
})

registerBtn.addEventListener("click", () => {
    btnsEffect.style.right = 0;
    btnsEffect.style.width = 160 + "px";
    btnsEffect.style.transition = ".2s"
    registerBtn.style.color = "white"
    loginBtn.classList.remove("active")

})
loginBtn.addEventListener("click", () => {
    btnsEffect.style.right = "58%";
    btnsEffect.style.width = 110 + "px";
    btnsEffect.style.transition = ".2s"
    registerBtn.style.color = "black"
    loginBtn.classList.add("active")
})
registerBtn.addEventListener("click", () => {
    registerForm.style.display = "grid";
    loginForm.style.display = "none";
})

loginBtn.addEventListener("click", () => {
    loginForm.style.display = "grid";
    registerForm.style.display = "none";
})