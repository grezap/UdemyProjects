<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Product;
class PostsController extends Controller
{
    //
    public function index(){
        $posts = Product::all();
        return view('posts.index',compact('posts'));
    }
}
