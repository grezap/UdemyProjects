<?php

use App\Post;
use Illuminate\Support\Facades\Route;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\SoftDeletes;
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

Route::get('/insert', function () {
    DB::insert('insert into post(title, content) values(?, ?);',['PHP with Laravel','Laravel is the best framework.']);
});

Route::get('/read', function () {
    $results = DB::select('select * from post where id = ?', [1]);
    foreach ($results as $post) {
        return $post->title;
    }
});

Route::get('/update', function () {
    $update = DB::update('update post set title = "Updated title" where id = ?', [2]);
    return $update;
});

Route::get('/delete', function () {
    $deleted = DB::delete('delete from post where id = ?',[1]);
    return $deleted;
});

//ELOQUENT ORM

Route::get('/readall', function () {
    $posts = Post::all();
    foreach ($posts as $post) {
        return $post->title; 
    }
});

Route::get('/find', function () {
    $post = Post::find(2);

        return $post->title; 

});

Route::get('/findwhere', function () {
    $post = Post::where('id',2)->orderBy('id','desc')->take(1)->get();
    return $post;
});

Route::get('/findmore', function () {
    $posts = Post::where('is_admin',0)->firstOrFail();
    return $posts;
});

Route::get('/basicinsert', function () {
    $post = new Post;
    $post->title = 'New Eloquent title 11';
    $post->content = 'Eloquent ORM test basic insert functionality 11';
    $post->save();
});

Route::get('/basicupdate', function () {
    $post = Post::find(2);
    $post->title = 'New Eloquent title';
    $post->save();
});

Route::get('/createmany', function () {
    Post::create(['title'=>'the create method','content'=>'I am from the routes create method']);
});

Route::get('/updateElo', function () {
    Post::where('id',2)->where('is_admin',0)->update(['title'=>'new eloquent update','content'=>'content for the eloquent update']);
});

Route::get('/deleteElo', function () {
    $post = Post::find(2);
    $post->delete();
});

Route::get('/deleteElo2', function () {
    Post::destroy(3);
});

Route::get('/deleteMany', function () {
    Post::destroy([4,5]);
});

Route::get('/softdelete', function () {
    Post::find(7)->delete();
});

Route::get('/readsoftdelete', function () {
    // $post = Post::find(10);
    // return $post;
    return Post::withTrashed()->get();
});

Route::get('/readsoftonlytrashed', function () {
    // $post = Post::find(10);
    // return $post;
    return Post::onlyTrashed()->get();
});

Route::get('/restoretrashed', function () {
    Post::withTrashed()->restore();
});

Route::get('/forcedelete', function () {
    Post::withTrashed()->where('id',7)->forceDelete();
});

Route::get('user/{id}/post', function ($id) {
    return User::find($id)->post;
});

Route::get('post/{id}/user', function ($id) {
    return Post::find($id)->user->name;
});

Route::get('/postsMany', function () {
    $user = User::find(1);
    foreach ($user->posts as $post) {
        echo $post->title ."<br>";
    }
});

Route::get('/user/{id}/role', function ($id) {
    $user = User::find($id);
    foreach ($user->roles as $role) {
        return $role->name;
    }
});

//access the intermediate table
Route::get('user/pivot', function () {
    $user = User::find(1);
    foreach ($user->roles as $role) {
        echo $role->pivot->created_at;
    }
});

// Route::get('/about', function () {
//     return view('Hi From About Page');
// });

// Route::get('/contact', function () {
//     return view('Hi From Contact Page');
// });

// Route::get('post/{id}/{name}', function ($id, $name) {
//     return "This is post number ".$id." ".$name;
// });

// Route::get('admin/posts/example', array('as'=>'admin.home', function () {
//     $url = route('admin.home');
//     return "this url is ". $url;
// }));

//Route::get('/post/{id}','PostController@index');

Route::resource('posts', 'PostController');
Route::get('/contact','PostController@contact');
Route::get('post/{id}/{name}','PostController@showPost');

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
