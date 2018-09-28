<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use App\Http\Requests;
use App\Post;
use App\Http\Requests\CreatePostRequest;

class PostsController extends Controller
{
    //

    public function index(){
        $posts = Post::latest(); // this comes from model query scope
        //dd($posts);
        return view('posts.index',compact('posts'));
    }

    public function store(CreatePostRequest $request){

        // $this->validate($request,[
        //     'title'=>'required|max:50',
        //     'content'=>'required'
        // ]);
        
        $file = $request->file('file');
        
        $post = new Post();

        if ($file = $request->file('file')) {
            $name = $file->getClientOriginalName();
            $file->move('images', $name);
            $post->path = $name;
        }

        
        $post->title=$request->title;
        $post->content = $request->content;
        $post->save();
        return redirect('/posts');
    }

    public function create(){
        return view('posts.create');
    }

    public function show($id){
        $post = Post::withTrashed()->find($id);
        //dd($post);
        return view('posts.show',compact('post'));
    }

    public function edit($id){
        $post = Post::withTrashed()->find($id);
        return view('posts.edit', compact('post'));
    }

    public function update(Request $request, $id){
        $post = Post::find($id);
        $post->title = $request->title;
        $post->save();
        return redirect('/posts');;
    }

    public function destroy($id){
        $post = Post::withTrashed()->find($id);
        if ($post->trashed()) {
            $post->forceDelete();
        }else{
            $post->delete();
        }
        
        return redirect('/posts');
    }
}
