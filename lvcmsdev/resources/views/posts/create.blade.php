@extends('layouts.app')
@section('content')
    <h1>Create Post</h1>
    
     {{-- <form action="/posts" method="post"> --}}
    {!! Form::open(['method'=>'POST','action'=>'PostsController@store', 'files'=>true]) !!}

        <div class="form-group">
            {!! Form::label('title','Title: ') !!}
            {!! Form::text('title',null,['class'=>'form-control','placeholder'=>'Post Title']) !!}
            {!! Form::text('content',null,['class'=>'form-control', 'placeholder'=>'Post Content']) !!}
        </div>
        <div class="form-group">
            {!! Form::file('file',['class'=>'form-control']) !!}
        </div>
        <br />
        <div class="form-group">
            {!! Form::submit('Create Post',['class'=>'btn btn-primary']) !!}
        </div>
    {!! Form::close() !!}
    @if (count($errors)>0)
        <div class="alert">
            <ul>
                @foreach ($errors->all() as $error)
                    <li>{{ $error }}</li>
                @endforeach
            </ul>
        </div>

    @endif
@endsection
