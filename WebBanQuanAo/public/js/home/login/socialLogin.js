var typeLogin = {
    byFB: 1,
    byGG: 2
};

/*
 * Load API củ Facebook
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :   
 * Output       :   
 */
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/vi_VN/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

/*
 * Khởi tạo đối tượng facebook
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :  
 * Output       :   
 */
window.fbAsyncInit = function () {
    FB.init({
        appId: $('meta[property="fb:app_id"]').attr('content'),
        status: true,
        cookie: true,
        xfbml: false,
        version: 'v3.0'
    });
};

/*
 * Login bằng tài khoản facebook
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :   
 * Output       :   
 */
function loginByFB() {
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            CheckSocialLogin(response.authResponse.accessToken, typeLogin.byFB);
        }
        else {
            FB.login(function (response) {
                CheckSocialLogin(response.authResponse.accessToken, typeLogin.byFB);
            }, { scope: 'public_profile,email'});
        }
    });
} 

/*
 * Khởi tạo sự kiện và đối tượng login bằng google
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :   
 * Output       :   
 */
function startAppGG() {
    gapi.load('auth2', function () {
        auth2 = gapi.auth2.init({
            client_id: $('meta[name="google-signin-client_id"]').attr('content'),
            cookiepolicy: 'single_host_origin'
        });
        attachSignin(document.getElementById('btn-login-GG'));
    });
};

/*
 * Thực hiện login vào google plus khi click button login by google
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :   
 * Output       :   
 */
function attachSignin(element) {
    auth2.attachClickHandler(element, {},
        function (googleUser) {
            CheckSocialLogin(googleUser.Zi.access_token, typeLogin.byGG);
        }, function (error) {
            jMessage(0, function (ok) {
            }, '<b>Attach Signin:</b> ' + JSON.stringify(error, undefined, 2), 4);
        });
}

/*
 * Đồng bộ tài khoản củ FB hoặc GG với hệ thống
 * Author       :   HoangNM - 20/01/2019 - create
 * Param        :   
 * Output       :   
 */
function CheckSocialLogin(accessToken, type) {
    alert(url.socialLogin);
    $.ajax({
        type: 'GET',
        url: url.socialLogin + '?accessToken=' + accessToken + '&&type=' + type,
        success: CheckLoginSuccess
    });
}