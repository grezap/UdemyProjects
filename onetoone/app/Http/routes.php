<?php

use App\Address;
use App\User;

/*
  |--------------------------------------------------------------------------
  | Routes File
  |--------------------------------------------------------------------------
  |
  | Here is where you will register all of the routes in an application.
  | It's a breeze. Simply tell Laravel the URIs it should respond to
  | and give it the controller to call when that URI is requested.
  |
 */

Route::get('/', function () {
    return view('welcome');
});

Route::get('/insertUserAddress/{id}', function ($id) {
    $user = User::findOrFail($id);
    $address = new Address(['name' => '4435 Paulina Avenue NY NY 11218']);
    $user->address()->save($address);
});

Route::get('/insertuser', function () {
    $user = new User();
    $user->name = 'gza';
    $user->email = 'gza@onetoone.com';
    $user->password = '1234';
    $user->created_at = '2018-09-23';
    $user->updated_at = '2018-09-23';
    $user->save();
});

Route::get('/updateaddress', function () {
    $address = Address::where('user_id', 1)->first();
    $address->name = "4353 Updated Avenue Alaska";
    $address->save();
});

Route::get('/read', function() {
    $user = User::findOrFail(1);
    echo $user->address->name;
});

Route::get('/delete', function() {
    $user = User::findOrFail(1);
    echo $user->address()->delete();
});
/*
  |--------------------------------------------------------------------------
  | Application Routes
  |--------------------------------------------------------------------------
  |
  | This route group applies the "web" middleware group to every route
  | it contains. The "web" middleware group is defined in your HTTP
  | kernel and includes session state, CSRF protection, and more.
  |
 */

Route::group(['middleware' => ['web']], function () {
    //
});
