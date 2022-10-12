<?php

namespace Config;

// Create a new instance of our RouteCollection class.
$routes = Services::routes();

// Load the system's routing file first, so that the app and ENVIRONMENT
// can override as needed.
if (is_file(SYSTEMPATH . 'Config/Routes.php')) {
    require SYSTEMPATH . 'Config/Routes.php';
}

/*
 * --------------------------------------------------------------------
 * Router Setup
 * --------------------------------------------------------------------
 */
$routes->setDefaultNamespace('App\Controllers');
$routes->setDefaultController('Home');
$routes->setDefaultMethod('index');
$routes->setTranslateURIDashes(false);
$routes->set404Override();
// The Auto Routing (Legacy) is very dangerous. It is easy to create vulnerable apps
// where controller filters or CSRF protection are bypassed.
// If you don't want to define all routes, please use the Auto Routing (Improved).
// Set `$autoRoutesImproved` to true in `app/Config/Feature.php` and set the following to true.
// $routes->setAutoRoute(false);

/*
 * --------------------------------------------------------------------
 * Route Definitions
 * --------------------------------------------------------------------
 */

// We get a performance increase by specifying the default
// route since we don't have to scan directories.
// $routes->get('/', 'Home::index');
$routes->get('/', 'Dashboard::index');
$routes->get('/dashboard', 'Dashboard::index');
$routes->get('index-dark', 'Dashboard::show_index_dark');
$routes->get('index-rtl', 'Dashboard::show_index_rtl');
$routes->get('layouts-boxed', 'Dashboard::show_layouts_boxed');
$routes->get('layouts-colored-sidebar', 'Dashboard::show_colored_sidebar');
$routes->get('layouts-compact-sidebar', 'Dashboard::show_compact_sidebar');
$routes->get('layouts-dark-sidebar', 'Dashboard::show_dark_sidebar');
$routes->get('layouts-icon-sidebar', 'Dashboard::show_icon_sidebar');
$routes->get('layouts-scrollable', 'Dashboard::show_layouts_scrollable');

//SISTEM PAKAR
$routes->get('/pasien', 'Dashboard::pasien');
$routes->get('/gejala', 'Dashboard::gejala');
$routes->get('/pengetahuan', 'Dashboard::pengetahuan');
$routes->get('/penyakit', 'Dashboard::penyakit');


// //Layout section routing
$routes->get('layouts-horizontal', 'Dashboard::show_layouts_horizontal');
$routes->get('layouts-horizontal-boxed', 'Dashboard::show_layouts_horizontal_boxed');
$routes->get('layouts-horizontal-dark', 'Dashboard::show_layouts_horizontal_dark');
$routes->get('layouts-horizontal-rtl', 'Dashboard::show_layouts_horizontal_rtl');
$routes->get('layouts-horizontal-scrollable', 'Dashboard::show_layouts_horizontal_scrollable');
$routes->get('layouts-horizontal-dark-topbar', 'Dashboard::show_layouts_dark_topbar');


// //App section routing
$routes->get('profile', 'Dashboard::show_contacts_profile');

// Pages
// $routes->get('auth-login', 'Dashboard::show_auth_login');
// $routes->get('auth-register', 'Dashboard::show_auth_register');
// $routes->get('auth-recoverpw', 'Dashboard::show_auth_recoverpw');
// $routes->get('auth-lock-screen', 'Dashboard::show_auth_lock_screen');
// $routes->get('auth-confirm-mail', 'Dashboard::show_auth_confirm_mail');
// $routes->get('auth-email-verification', 'Dashboard::show_auth_email_verification');
// $routes->get('auth-two-step-verification', 'Dashboard::show_auth_two_step_verification');





/*
 * --------------------------------------------------------------------
 * Additional Routing
 * --------------------------------------------------------------------
 *
 * There will often be times that you need additional routing and you
 * need it to be able to override any defaults in this file. Environment
 * based routes is one such time. require() additional route files here
 * to make that happen.
 *
 * You will have access to the $routes object within that file without
 * needing to reload it.
 */
if (is_file(APPPATH . 'Config/' . ENVIRONMENT . '/Routes.php')) {
    require APPPATH . 'Config/' . ENVIRONMENT . '/Routes.php';
}