<?php

use App\Staff;
use App\Product;
use App\Photo;

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

Route::get('/createstaff/{name}', function ($name) {
    $staff = new Staff();
    $staff->name = $name;
    $staff->save();
});

Route::get('/createproduct/{name}', function ($name) {
    $prod = new Product();
    $prod->name=$name;
    $prod->save();
});

Route::get('/createstaffphoto/{id}', function ($id) {
    $photo = new Photo();
    $photo->path = 'example'.$id.'.jpg';
    $staff = Staff::find($id);
    $staff->photos()->save($photo);
});

Route::get('/createproductphoto/{id}', function ($id) {
    $photo = new Photo();
    $photo->path='prodexample'.$id.'.jpg';
    $prod = Product::find($id);
    $prod->photos()->save($photo);
});

Route::get('/readstaffphotos/{id}', function ($id) {
    $staff = Staff::find($id);
    foreach ($staff->photos as $photo) {
        echo $photo->path."<br>";
    }
});

Route::get('/updatestaffphoto/{id}/{photoid}', function ($id,$photoid) {
    $staff = Staff::find($id);
    $photo = $staff->photos()->where('id',$photoid)->first();
    $photo->path='updatedphoto'.$id.'.jpg';
    $photo->save();
});

Route::get('/deletestaffphoto/{id}/{photoid}', function ($id,$photoid) {
    $staff = Staff::find($id);
    $photo = $staff->photos()->find($photoid)->first();
    echo $photo;
    if ($photo==null) {
        return "photo with id ".$photoid." could not be found.";
    }
    $res = $photo->delete(); 
    if ($res) {
        return "deleted ".$photo->path." for ".$staff->name;
    }else {
        return "could not delete";
    }
});

Route::resource('/posts', 'PostsController');