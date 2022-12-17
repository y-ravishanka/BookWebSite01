

let novel0 = document.getElementById("novel0");
let hello = document.getElementById("hello");
let id01 = document.getElementById("id01");
let id02 = document.getElementById("id02");

novel0.addEventListener("click", function () {
    alert("hello");
    console.log("novel0 is working");
});

hello.addEventListener("click", function () {
    alert("Hi");
    console.log("hello is working")
});

id01.addEventListener("click", function () {
    id02.textContent = "Hi !!!";
    console.log("id01 is working")
});
