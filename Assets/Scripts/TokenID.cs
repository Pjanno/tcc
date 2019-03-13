using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenID {

    public int id;
    public string token;

    //GETTER AND SETTER
    public int getId()
    {
        return id;
    }
    public string getToken()
    {
        return token;
    }
    public void setId(int id)
    {
        this.id = id;
    }
    public void setToken(string token)
    {
        this.token = token;
    }
}
