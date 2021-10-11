using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniClicker : MonoBehaviour
{
    AudioSource audioCoin;
    AudioSource audioPiko;
    AudioSource audioMusic;

    public AudioClip coin;
    public AudioClip piko;
    public AudioClip music1;

    public GameObject addTextObj;
    public float clickrate = 0.5f;
    public float timeleft;
    public string tani = "";

    public float click = 0;
    public int anba = 0;
    public float anba_hiyou = 0;
    public int gaia = 0;
    public float gaia_hiyou = 0;
    public int lisa = 0;
    public float lisa_hiyou = 0;
    public int jin = 0;
    public float jin_hiyou = 0;

    Text countText, messageText;
    Text anba_text;
    Text gaia_text;
    Text lisa_text;
    Text jin_text;
    GameObject satou;
    GameObject canvas;
    GameObject anba_bt;
    GameObject gaia_bt;
    GameObject lisa_bt;
    GameObject jin_bt;
    GameObject Save;
    GameObject Exit;


    // Use this for initialization
    void Start()
    {

         audioCoin = GetComponent<AudioSource>();
         audioPiko = GetComponent<AudioSource>();
         audioMusic = GetComponent<AudioSource>();

        anba = 0;
        anba = PlayerPrefs.GetInt("anbaCount");
        anba_hiyou = anba * 10 + 100;
        gaia = 0;
        gaia = PlayerPrefs.GetInt("gaiaCount");
        gaia_hiyou = gaia * 1000 + 10000;
        lisa = 0;
        lisa = PlayerPrefs.GetInt("lisaCount");
        lisa_hiyou = lisa * 100000 + 1000000;
        jin = 0;
        jin = PlayerPrefs.GetInt("jinCount");
        jin_hiyou = jin * 10000000 + 100000000;
        click = 0;
        click = PlayerPrefs.GetFloat("ClickCount");
        countText = GameObject.Find("CountText").GetComponent<Text>();
        anba_text = GameObject.Find("anba_text").GetComponent<Text>();
        gaia_text = GameObject.Find("gaia_text").GetComponent<Text>();
        lisa_text = GameObject.Find("lisa_text").GetComponent<Text>();
        jin_text = GameObject.Find("jin_text").GetComponent<Text>();
        satou = GameObject.Find("satou");
        canvas = GameObject.Find("Canvas");
        anba_bt = GameObject.Find("anba_bt");
        gaia_bt = GameObject.Find("gaia_bt");
        lisa_bt = GameObject.Find("lisa_bt");
        jin_bt = GameObject.Find("jin_bt");
        Save = GameObject.Find("Save");
        Exit = GameObject.Find("Exit");
        messageText = GameObject.Find("MessageText").GetComponent<Text>();

        if (click > 1 * 1000000000000000)
        {
            tani = "P";
            click = click / 1000000000000000;
        }
        else if (click > 1 * 1000000000000)
        {
            tani = "T";
            click = click / 1000000000000;
        }
        else if (click > 1 * 1000000000)
        {
            tani = "G";
            click = click / 1000000000;
        }
        else if (click > 1 * 1000000)
        {
            tani = "M";
            click = click / 1000000;
        }
        else if (click > 1 * 1000)
        {
            tani = "K";
            click = click / 1000;
        }

        countText.text = (Mathf.Ceil(click*10))/10 + tani + "モラ";

        if(tani == "P")
        {
            click = click * 1000000000000000;
        }
        else if (tani == "T")
        {
            click = click * 1000000000000;
        }
        else if (tani == "G")
        {
            click = click * 1000000000;
        }
        else if (tani == "M")
        {
            click = click * 1000000;
        }
        else if (tani == "K")
        {
            click = click * 1000;
        }

        tani = "";

        if (anba_hiyou > 1 * 1000000000000000)
        {
            tani = "P";
            anba_hiyou = anba_hiyou / 1000000000000000;
        }
        else if(anba_hiyou > 1 * 1000000000000)
        {
            tani = "T";
            anba_hiyou = anba_hiyou / 1000000000000;
        }
        else if(anba_hiyou > 1 * 1000000000)
        {
            tani = "G";
            anba_hiyou = anba_hiyou / 1000000000;
        }
        else if(anba_hiyou > 1 * 1000000)
        {
            tani = "M";
            anba_hiyou = anba_hiyou / 1000000;
        }
        else if(anba_hiyou > 1 * 1000)
        {
            tani = "K";
            anba_hiyou = anba_hiyou / 1000;
        }

        anba_text.text = "アンバー　" + anba + "人\n費用　" + anba_hiyou + tani + "モラ";
        anba_hiyou = anba * 10 + 100;

        tani = "";

        if (gaia_hiyou > 1 * 1000000000000000)
        {
            tani = "P";
            gaia_hiyou = gaia_hiyou / 1000000000000000;
        }
        else if (gaia_hiyou > 1 * 1000000000000)
        {
            tani = "T";
            gaia_hiyou = gaia_hiyou / 1000000000000;
        }
        else if (gaia_hiyou > 1 * 1000000000)
        {
            tani = "G";
            gaia_hiyou = gaia_hiyou / 1000000000;
        }
        else if (gaia_hiyou > 1 * 1000000)
        {
            tani = "M";
            gaia_hiyou = gaia_hiyou / 1000000;
        }
        else if (gaia_hiyou > 1 * 1000)
        {
            tani = "K";
            gaia_hiyou = gaia_hiyou / 1000;
        }

        gaia_text.text = "ガイア　" + gaia + "人\n費用　" + gaia_hiyou + tani + "モラ";
        gaia_hiyou = gaia * 100 + 10000;

        tani = "";


        if (lisa_hiyou > 1 * 1000000000000000)
        {
            tani = "P";
            lisa_hiyou = lisa_hiyou / 1000000000000000;
        }
        else if (lisa_hiyou > 1 * 1000000000000)
        {
            tani = "T";
            lisa_hiyou = lisa_hiyou / 1000000000000;
        }
        else if (lisa_hiyou > 1 * 1000000000)
        {
            tani = "G";
            lisa_hiyou = lisa_hiyou / 1000000000;
        }
        else if (lisa_hiyou > 1 * 1000000)
        {
            tani = "M";
            lisa_hiyou = lisa_hiyou / 1000000;
        }
        else if (lisa_hiyou > 1 * 1000)
        {
            tani = "K";
            lisa_hiyou = lisa_hiyou / 1000;
        }

        lisa_text.text = "リサ　" + lisa + "人\n費用　" + lisa_hiyou + tani + "モラ";
        lisa_hiyou = lisa * 100000 + 1000000;

        tani = "";

        if (jin_hiyou > 1 * 1000000000000000)
        {
            tani = "P";
            jin_hiyou = jin_hiyou / 1000000000000000;
        }
        else if (jin_hiyou > 1 * 1000000000000)
        {
            tani = "T";
            jin_hiyou = jin_hiyou / 1000000000000;
        }
        else if (jin_hiyou > 1 * 1000000000)
        {
            tani = "G";
            jin_hiyou = jin_hiyou / 1000000000;
        }
        else if (jin_hiyou > 1 * 1000000)
        {
            tani = "M";
            jin_hiyou = jin_hiyou / 1000000;
        }
        else if (jin_hiyou > 1 * 1000)
        {
            tani = "K";
            jin_hiyou = jin_hiyou / 1000;
        }

        jin_text.text = "ジン　" + jin + "人\n費用　" + jin_hiyou + tani + "モラ";
        jin_hiyou = jin * 10000000 + 100000000;

        tani = "";

    }

    void Update()
    {

        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;

            click = click + anba * 1;
            click = click + gaia * 100;
            click = click + lisa * 10000;
            click = click + jin * 1000000;

            if (click > 1 * 1000000000000000)
            {
                tani = "P";
                click = click / 1000000000000000;
            }
            else if (click > 1 * 1000000000000)
            {
                tani = "T";
                click = click / 1000000000000;
            }
            else if (click > 1 * 1000000000)
            {
                tani = "G";
                click = click / 1000000000;
            }
            else if (click > 1 * 1000000)
            {
                tani = "M";
                click = click / 1000000;
            }
            else if (click > 1 * 1000)
            {
                tani = "K";
                click = click / 1000;
            }

            countText.text = (Mathf.Ceil(click * 10)) / 10 + tani +"モラ";

            if (tani == "P")
            {
                click = click * 1000000000000000;
            }
            else if (tani == "T")
            {
                click = click * 1000000000000;
            }
            else if (tani == "G")
            {
                click = click * 1000000000;
            }
            else if (tani == "M")
            {
                click = click * 1000000;
            }
            else if (tani == "K")
            {
                click = click * 1000;
            }

            tani = "";
        }

        if (timeleft <= 0.0)
        {
            timeleft = 60.0f;
            PlayerPrefs.SetFloat("ClickCount", click);
            PlayerPrefs.SetInt("anbaCount", anba);
            PlayerPrefs.SetInt("gaiaCount", gaia);
            PlayerPrefs.SetInt("lisaCount", lisa);
            PlayerPrefs.SetInt("jinCount", jin);
            PlayerPrefs.Save();
        }

            if (Input.GetMouseButtonUp(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit)
            {
                if (hit.transform.tag == "Save")
                {
                    cSave();
                }
                if (hit.transform.tag == "Finish")
                {
                    cExit();
                }
                if (hit.transform.tag == "satou")
                {
                    Click();
                }
                if (hit.transform.tag == "anba")
                {
                    anba_click();
                }
                if (hit.transform.tag == "gaia")
                {
                    gaia_click();
                }
                if (hit.transform.tag == "lisa")
                {
                    lisa_click();
                }
                if (hit.transform.tag == "jin")
                {
                    jin_click();
                }
            }





        }

        if (click > 100000000)
        {
            messageText.text = "あなたは全てができる\n合成、レベルアップ、強化";
        }
        else if (click > 1000000)
        {
            messageText.text = "あなたは不自由なく今日一日を過ごす事ができる";
        }
        else if (click > 500000)
        {
            messageText.text = "あなたは少しの余裕をもって今日一日を過ごす事ができる";
        }
        else if (click > 200000)
        {
            messageText.text = "あなたは今日一日過ごす事ができる\n何もしないのならば";
        }
        else if (click > 10000)
        {
            messageText.text = "あなたはモラ不足で食事すらできない";
        }
        else if (click <= 10000)
        {
            messageText.text = "あなたはモラ不足で何もできない";
        }

    }

    void cSave()
    {
        PlayerPrefs.SetFloat("ClickCount", click);
        PlayerPrefs.SetInt("anbaCount", anba);
        PlayerPrefs.SetInt("gaiaCount", gaia);
        PlayerPrefs.SetInt("lisaCount", lisa);
        PlayerPrefs.SetInt("jinCount", jin);
        PlayerPrefs.Save();
        audioCoin.PlayOneShot(piko);
    }

    void cExit()
    {
        Application.Quit();
    }

    void Click()
    {
        click++;
        GameObject obj = Instantiate(addTextObj);
        obj.transform.position = Input.mousePosition;
        obj.transform.SetParent(canvas.transform);
        obj.AddComponent<ObjectDestroy>();

        if (click > 1 * 1000000000000000)
        {
            tani = "P";
            click = click / 1000000000000000;
        }
        else if (click > 1 * 1000000000000)
        {
            tani = "T";
            click = click / 1000000000000;
        }
        else if (click > 1 * 1000000000)
        {
            tani = "G";
            click = click / 1000000000;
        }
        else if (click > 1 * 1000000)
        {
            tani = "M";
            click = click / 1000000;
        }
        else if (click > 1 * 1000)
        {
            tani = "K";
            click = click / 1000;
        }

        countText.text = (Mathf.Ceil(click * 10)) / 10 + tani + "モラ";

        if (tani == "P")
        {
            click = click * 1000000000000000;
        }
        else if (tani == "T")
        {
            click = click * 1000000000000;
        }
        else if (tani == "G")
        {
            click = click * 1000000000;
        }
        else if (tani == "M")
        {
            click = click * 1000000;
        }
        else if (tani == "K")
        {
            click = click * 1000;
        }

        tani = "";

        audioCoin.PlayOneShot(coin);
    }

    void anba_click()
    {
        if (click >= anba_hiyou)
        {
            anba++;
            click = click - anba_hiyou;
            anba_hiyou = anba * 10 + 100;
            if (anba_hiyou > 1 * 1000000000000000)
            {
                tani = "P";
                anba_hiyou = anba_hiyou / 1000000000000000;
            }
            else if (anba_hiyou > 1 * 1000000000000)
            {
                tani = "T";
                anba_hiyou = anba_hiyou / 1000000000000;
            }
            else if (anba_hiyou > 1 * 1000000000)
            {
                tani = "G";
                anba_hiyou = anba_hiyou / 1000000000;
            }
            else if (anba_hiyou > 1 * 1000000)
            {
                tani = "M";
                anba_hiyou = anba_hiyou / 1000000;
            }
            else if (anba_hiyou > 1 * 1000)
            {
                tani = "K";
                anba_hiyou = anba_hiyou / 1000;
            }

            anba_text.text = "アンバー　" + anba + "人\n費用　" + anba_hiyou + tani + "モラ";
            anba_hiyou = anba * 10 + 100;

            tani = "";

            if (click > 1 * 1000000000000000)
            {
                tani = "P";
                click = click / 1000000000000000;
            }
            else if (click > 1 * 1000000000000)
            {
                tani = "T";
                click = click / 1000000000000;
            }
            else if (click > 1 * 1000000000)
            {
                tani = "G";
                click = click / 1000000000;
            }
            else if (click > 1 * 1000000)
            {
                tani = "M";
                click = click / 1000000;
            }
            else if (click > 1 * 1000)
            {
                tani = "K";
                click = click / 1000;
            }

            countText.text = (Mathf.Ceil(click * 10)) / 10 + tani + "モラ";

            if (tani == "P")
            {
                click = click * 1000000000000000;
            }
            else if (tani == "T")
            {
                click = click * 1000000000000;
            }
            else if (tani == "G")
            {
                click = click * 1000000000;
            }
            else if (tani == "M")
            {
                click = click * 1000000;
            }
            else if (tani == "K")
            {
                click = click * 1000;
            }

            tani = "";
            audioCoin.PlayOneShot(piko);
        }
        else
        {
            audioMusic.PlayOneShot(music1);
        }
    }

    void gaia_click()
    {
        if (click >= gaia_hiyou)
        {
            gaia++;
            click = click - gaia_hiyou;
            gaia_hiyou = gaia * 100 + 10000;
            if (gaia_hiyou > 1 * 1000000000000000)
            {
                tani = "P";
                gaia_hiyou = gaia_hiyou / 1000000000000000;
            }
            else if (gaia_hiyou > 1 * 1000000000000)
            {
                tani = "T";
                gaia_hiyou = gaia_hiyou / 1000000000000;
            }
            else if (gaia_hiyou > 1 * 1000000000)
            {
                tani = "G";
                gaia_hiyou = gaia_hiyou / 1000000000;
            }
            else if (gaia_hiyou > 1 * 1000000)
            {
                tani = "M";
                gaia_hiyou = gaia_hiyou / 1000000;
            }
            else if (gaia_hiyou > 1 * 1000)
            {
                tani = "K";
                gaia_hiyou = gaia_hiyou / 1000;
            }

            gaia_text.text = "ガイア　" + gaia + "人\n費用　" + gaia_hiyou + tani + "モラ";
            gaia_hiyou = gaia * 100 + 10000;

            tani = "";

            if (click > 1 * 1000000000000000)
            {
                tani = "P";
                click = click / 1000000000000000;
            }
            else if (click > 1 * 1000000000000)
            {
                tani = "T";
                click = click / 1000000000000;
            }
            else if (click > 1 * 1000000000)
            {
                tani = "G";
                click = click / 1000000000;
            }
            else if (click > 1 * 1000000)
            {
                tani = "M";
                click = click / 1000000;
            }
            else if (click > 1 * 1000)
            {
                tani = "K";
                click = click / 1000;
            }

            countText.text = (Mathf.Ceil(click * 10)) / 10 + tani + "モラ";

            if (tani == "P")
            {
                click = click * 1000000000000000;
            }
            else if (tani == "T")
            {
                click = click * 1000000000000;
            }
            else if (tani == "G")
            {
                click = click * 1000000000;
            }
            else if (tani == "M")
            {
                click = click * 1000000;
            }
            else if (tani == "K")
            {
                click = click * 1000;
            }

            tani = "";
            audioCoin.PlayOneShot(piko);
        }
        else
        {
            audioMusic.PlayOneShot(music1);
        }
    }

    void lisa_click()
        {
            if (click >= lisa_hiyou)
            {
                lisa++;
                click = click - lisa_hiyou;
                lisa_hiyou = lisa * 100000 + 1000000;
            if (lisa_hiyou > 1 * 1000000000000000)
                {
                    tani = "P";
                    lisa_hiyou = lisa_hiyou / 1000000000000000;
                }
                else if (lisa_hiyou > 1 * 1000000000000)
                {
                    tani = "T";
                    lisa_hiyou = lisa_hiyou / 1000000000000;
                }
                else if (lisa_hiyou > 1 * 1000000000)
                {
                    tani = "G";
                    lisa_hiyou = lisa_hiyou / 1000000000;
                }
                else if (lisa_hiyou > 1 * 1000000)
                {
                    tani = "M";
                    lisa_hiyou = lisa_hiyou / 1000000;
                }
                else if (lisa_hiyou > 1 * 1000)
                {
                    tani = "K";
                    lisa_hiyou = lisa_hiyou / 1000;
                }

                lisa_text.text = "リサ　" + lisa + "人\n費用　" + lisa_hiyou + tani + "モラ";
                lisa_hiyou = lisa * 100000 + 1000000;

                tani = "";

            if (click > 1 * 1000000000000000)
            {
                tani = "P";
                click = click / 1000000000000000;
            }
            else if (click > 1 * 1000000000000)
            {
                tani = "T";
                click = click / 1000000000000;
            }
            else if (click > 1 * 1000000000)
            {
                tani = "G";
                click = click / 1000000000;
            }
            else if (click > 1 * 1000000)
            {
                tani = "M";
                click = click / 1000000;
            }
            else if (click > 1 * 1000)
            {
                tani = "K";
                click = click / 1000;
            }

            countText.text = (Mathf.Ceil(click * 10)) / 10 + tani + "モラ";

            if (tani == "P")
            {
                click = click * 1000000000000000;
            }
            else if (tani == "T")
            {
                click = click * 1000000000000;
            }
            else if (tani == "G")
            {
                click = click * 1000000000;
            }
            else if (tani == "M")
            {
                click = click * 1000000;
            }
            else if (tani == "K")
            {
                click = click * 1000;
            }

            tani = "";
            audioCoin.PlayOneShot(piko);
        }
        else
        {
            audioMusic.PlayOneShot(music1);
        }
    }

    void jin_click()
    {
        if (click >= jin_hiyou)
        {
            jin++;
            click = click - jin_hiyou;
            jin_hiyou = jin * 10000000 + 100000000;
            if (jin_hiyou > 1 * 1000000000000000)
                    {
                        tani = "P";
                        jin_hiyou = jin_hiyou / 1000000000000000;
                    }
                    else if (jin_hiyou > 1 * 1000000000000)
                    {
                        tani = "T";
                        jin_hiyou = jin_hiyou / 1000000000000;
                    }
                    else if (jin_hiyou > 1 * 1000000000)
                    {
                        tani = "G";
                        jin_hiyou = jin_hiyou / 1000000000;
                    }
                    else if (jin_hiyou > 1 * 1000000)
                    {
                        tani = "M";
                        jin_hiyou = jin_hiyou / 1000000;
                    }
                    else if (jin_hiyou > 1 * 1000)
                    {
                        tani = "K";
                        jin_hiyou = jin_hiyou / 1000;
                    }
                    jin_text.text = "ジン　" + jin + "人\n費用　" + jin_hiyou + tani + "モラ";
                    jin_hiyou = jin * 10000000 + 100000000;

                    tani = "";
            if (click > 1 * 1000000000000000)
            {
                tani = "P";
                click = click / 1000000000000000;
            }
            else if (click > 1 * 1000000000000)
            {
                tani = "T";
                click = click / 1000000000000;
            }
            else if (click > 1 * 1000000000)
            {
                tani = "G";
                click = click / 1000000000;
            }
            else if (click > 1 * 1000000)
            {
                tani = "M";
                click = click / 1000000;
            }
            else if (click > 1 * 1000)
            {
                tani = "K";
                click = click / 1000;
            }

            countText.text = (Mathf.Ceil(click * 10)) / 10 + tani + "モラ";

            if (tani == "P")
            {
                click = click * 1000000000000000;
            }
            else if (tani == "T")
            {
                click = click * 1000000000000;
            }
            else if (tani == "G")
            {
                click = click * 1000000000;
            }
            else if (tani == "M")
            {
                click = click * 1000000;
            }
            else if (tani == "K")
            {
                click = click * 1000;
            }

            tani = "";
            audioCoin.PlayOneShot(piko);
        }
        else
        {
            audioMusic.PlayOneShot(music1);
        }
    }

        private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("ClickCount",click);
        PlayerPrefs.SetInt("anbaCount", anba);
        PlayerPrefs.SetInt("gaiaCount", gaia);
        PlayerPrefs.SetInt("lisaCount", lisa);
        PlayerPrefs.SetInt("jinCount", jin);
        PlayerPrefs.Save();
    }


}

public class ObjectDestroy : MonoBehaviour{

    float destroyTime = 0.5f;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (destroyTime <= timer)
        {
            Destroy(gameObject);
        }
    }

}
