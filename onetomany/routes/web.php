<?php

use App\Post;
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

Route::get('/create', function(){
    $user = User::findOrFail(1);
    $post = new Post(['title'=>'My second post with gza','body'=>'body for the second post for gza']);
    $user->posts()->save($post);
});

Route::get('/read', function(){
    $user = User::findOrFail(1);
    foreach ($user->posts as $post) {
        echo $post->title."<br>";
    }
});

Route::get('/update', function(){

    $user = User::findOrFail(1); /*@var $user App\User */
    $user->posts()->where('id',1)->update(['title'=>'Updated Title','body'=>'updated body']);
});

Route::get('/delete', function(){
    $user = User::find(1);
    $user->posts()->where('id',1)->delete();
    
});