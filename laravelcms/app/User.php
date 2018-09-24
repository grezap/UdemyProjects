<?php

namespace App;

use Illuminate\Foundation\Auth\User as Authenticatable;

class User extends Authenticatable
{
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'name', 'email', 'password',
    ];

    /**
     * The attributes excluded from the model's JSON form.
     *
     * @var array
     */
    protected $hidden = [
        'password', 'remember_token',
    ];

    public function post()
    {
        return $this->hasOne('App\Post','user_id');
    }

    public function posts()
    {
        return $this->hasMany('App\Post');       
    }

    public function roles()
    {
        return $this->belongsToMany('App\Role')->withPivot('created_at');    
        //if we have custom name e.g. user_roles we can write the function as 
        // return $this->belongsToMany('App\Role','user_roles', 'user_id', 'role_id');     
    }
}
