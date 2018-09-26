<?php

use App\Country;
use App\Photo;
use App\Post;
use App\Role;
use App\Tag;
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

Route::get('basicinsert', function () {
    $post = new Post;
    $post->title = 'New Eloquent title insert';
    $post->content = 'Eloquent test content for the new title';
    $post->save();
});

Route::get('/create', function ($id) {
    Post::create(['title'=>'from create method','content'=>'content from create method']);
});

Route::get('/user/{id}/role', function ($id) {
    $user  = User::find($id);
    foreach ($user->roles as $role) {
        return $role->name;
    }
});

//Many to Many relationships
Route::get('user/{id}/pivot', function ($id) {
    $user = User::find($id);
    foreach ($user->roles as $role) {
        echo $role->pivot->created_at;
    }
});

Route::get('/country/{id}/posts', function ($id) {
    $country = Country::find($id);
    foreach ($country->posts as $post) {
        return $post->title."-".$post->content;
    }
});

// Polymorphic realations

Route::get('/userphotos/{id}', function ($id) {
    $user = User::find($id);
    foreach ($user->photos as $photo) {
        echo $photo;
    }
});

Route::get('photo/{id}/post', function ($id) {
    $photo = Photo::findOrFail($id);
    return $photo->imageable;
});


// Polymorphic many to many realations
Route::get('post/tags', function () {
    $post = Post::find(1);
    foreach ($post->tags as $tag) {
        echo $tag->name;
    }
});

Route::get('tag/posts', function () {
    $tag = Tag::find(2);
    foreach ($tag->posts as $post) {
        echo $post->title;
    }
});

Route::resource('/posts', 'PostsController');

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
