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
        return $this->hasOne('App\Post'); // the model expects to find a foreign key in the post table with the name user_id
        //if we had named the column with a different name e.g usersid then we can tell this to the hasOne method like hasOne('App\Post','usersid')
    }

    public function posts()
    {
        return $this->hasMany('App\Post');
    }

    public function roles()
    {
        return $this->belongsToMany('App\Role')->withPivot(['created_at']);//if the table name is different e.g. user_roles then it becomes belongsToMany('App\Role','user_roles')
    }

    public function photos()
    {
        return $this->morphMany('App\Photo','imageable');
    }
}
