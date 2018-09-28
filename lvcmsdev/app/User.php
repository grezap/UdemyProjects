<?php

namespace App;

use Illuminate\Notifications\Notifiable;
use Illuminate\Foundation\Auth\User as Authenticatable;

class User extends Authenticatable
{
    use Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'name', 'email', 'password',
    ];

    /**
     * The attributes that should be hidden for arrays.
     *
     * @var array
     */
    protected $hidden = [
        'password', 'remember_token',
    ];

    // Accessor: accessors are applied after we get the data from database and they make the changes we want before they reach the view.
    // They must start with word get and they must end with word Attribute. Also the value is what we get from the database.
    public function getNameAttribute($value)
    {
        return ucfirst($value);
    }

    // Mutetor: mutators are applied before the data are saved to the database and change the data as we need to.
    // They must start with word set and they must end with word Attribute.
    // So every time we save a User Model, when we modify the name attribute, this rule will be applied before it is saved in the database. 
    public function setNameAttribute($value)
    {
        $this->attributes['name'] = strtoupper($value);
    }

}
