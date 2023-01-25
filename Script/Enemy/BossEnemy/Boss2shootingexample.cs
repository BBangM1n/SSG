using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2shootingexample : MonoBehaviour
{
    public GameObject bullet;
    float num;
    int Pt;
    int stopcord;
    public Boss2 boss;

    void Start(){
        StartCoroutine(Bullet());
        num = 0;
        stopcord = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Pattern();
    }

    IEnumerator Bullet(){
        Vector2 vec = new Vector2(transform.position.x, transform.position.y + num);
        Instantiate(bullet, vec, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Bullet());
    }

    void numsum()
    {
        num += 0.01f;
    }

    void nummic()
    {
        num -= 0.01f;
    }
    void Pattern()
    {
        if(boss.Nowhp <= 100)
            Pattern1();
            if(boss.Nowhp <= 50)
            Pt = 2;
        if(boss.Nowhp <= 50 && Pt == 2)
            Pattenr2();
            if(boss.Nowhp <= 20)
            Pt = 3;
        if(boss.Nowhp <= 20 && Pt == 3)
            Pattenr3();
    }

    void Pattern1()
    {
        if(num < 3 && stopcord == 0)
            numsum();
            if(num >= 3)
                stopcord = 1;
        if(stopcord == 1)
            nummic();
            if(num <= -3)
                stopcord = 0;
    }

    void Pattenr2()
    {
        if(num < 3 && stopcord == 0)
            numsum2();
            if(num >= 3)
                stopcord = 1;
        if(stopcord == 1)
            nummic2();
            if(num <= -3)
                stopcord = 0;
    }

    void Pattenr3()
    {
        if(num < 3 && stopcord == 0)
            numsum3();
            if(num >= 3)
                stopcord = 1;
        if(stopcord == 1)
            nummic3();
            if(num <= -3)
                stopcord = 0;
    }

    void numsum2()
    {
        num += 0.015f;
    }

    void nummic2()
    {
        num -= 0.015f;
    }

    void numsum3()
    {
        num += 0.02f;
    }

    void nummic3()
    {
        num -= 0.02f;
    }
}
