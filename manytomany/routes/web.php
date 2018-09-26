<?php

use App\Role;
use App\User;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::get('/createuser', function(){
    $user = new User;
    $user->name = 'gza1';
    $user->password = '1234';
    $user->email = 'gza1@manytomany.com';
    $user->save();
});

Route::get('/createrole', function(){
    $role = new Role();
    $role->name='subscriber';
    $role->save();
});

Route::get('/assignroletouser/{id}', function($id){
    $user = User::find($id);
    $role = Role::find(2);
    $user->roles()->save($role);
});

Route::get('/getuserroles/{id}',function($id){
    $user = User::find($id);
    $roles = $user->roles;
    foreach ($roles as $role) {
        echo $role-> name. "<br/>";
    }
    foreach ($user->roles as $role) {
        echo $role-> name. "<br/>"; 
    }
});

Route::get('/updaterole',function(){
    $user = User::find(1);
    if($user->has('roles')){
        foreach ($user->roles as $role) {
            if ($role->name == 'administrator') {
                $role->name = strtolower('admin');
                $role->save();
            }
        }
    }
});

Route::get('/deleterole',function(){
    $user = User::find(1);
    $test = $user->roles->where('id',3)->find(3);
    echo $test->delete();
    //$roles->delete();
});