const container = document.getElementsByClassName('container')[0];
const signUp = document.getElementById('sign_up');
const signIn = document.getElementById('sign_in');

signIn.onclick = function () {
    container.classList.remove('active');
}
signUp.onclick = function () {
    container.classList.add('active');
}
