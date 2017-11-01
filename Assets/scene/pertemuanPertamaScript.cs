using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pertemuanPertamaScript : MonoBehaviour {

    public Text speech; // TEXT PERKATAAN
    public Button p1, p2, p3, p4; // EMPAT PILIHAN TOMBOL
    public GameObject panelInput; // PANEL UNTUK INPUT
    public Image photo; // PHOTO SAMPING 
    public Image background; // PHOTO BACKGROUND

    private enum State {
        perkenalan, pertanyaan, sudahbawa, belumbawa, hukuman, hukuman_benar, hukuman_salah, hukuman_keluar, game_over, hukuman_mencari, berjalan_mencari, didepan_pintu,
        bertanya_orang, dobrak_pintu, kembali_kemasnya, sukses_rayu, coba_lagi, gagal_rayu, gagal_rayu_poll, masuk_ruangan, ambil_buku, menang, win
    }
    private State state;
    private int index;  // INDEXING ARRAY PERCAKAPAN 
    private bool fquestion;  // AWAL PERCAKAPAN JIKA ADA
    private bool isGetKey;
    private bool isGetBook;

    private string[] perkenalan = {
            "Namaku hasan, aku mahasiswa udinus 2015, disini aku sebagai panitia dinus inside",
            "Kamu mahasiswa baru ya","" +
            "jika kamu ingin bertanya mengenai dinus inside bisa ke aku ya",
            "By the way, kalau boleh tau siapa namamu"
    };
    private string[] perkenalan_e = {
          "people1-flat",
          "people1-smile",
          "people1-smiling",
          "people1-smile-right"
    };

    private string[] pertanyaan = {
            "Selamat datang ya di dinus inside ",
            "Jangan malu ya, untuk berkenalan dengan teman-temanmu",
            "Oh ya!!, bagaimana barang kami suruh bawa udah kamu bawa belum ?"
    };

    private string[] pertanyaan_e = {
          "people1-smiling",
          "people1-smile",
          "people1-strange"
    };

            // ----- >
            private string[] sudahbawa = {
                             "Oh, sudah bawa baguslah",
                             "Soalnya kalau belum nanti aku hukum",
                             "Jangan bohong yaa !!!",
                             "Hmmm, Coba aku lihat tasmu",
                             "Tasmu diambil dan dipaksa buka oleh mas hasan",
                             "Loh kog tas mu kosong, gak ada isinya, niat gak sih kamu"
                        };
            private string[] sudahbawa_e = {
                          "people1-smiling",
                          "people1-smile",
                          "people1-strange",
                          "people1-strange",
                          "tas3",
                          "tas-kosong"
                    };

            //------>


            private string[] belumbawa = {
                            
                            "Kamu gak bawa barang-barang yang kami suruh bawa!, bagaimana kamu itu",
                             "Ya sudah kamu saya hukum!!",
                             "Tenang kog hukumannya gak berat-berat amat"
                    };

            private string[] belumbawa_e = {
                          "people1-sad-left",
                          "people1-sad",
                          "people1-smile-evil"
                    };
                    //------>

                    private string[] hukuman = {
                            "Hmmm, tapi sebelum itu kamu harus menjawab pertanyaanku",
                            "Jika kamu dapat menjawab pertanyaan ini kamu bisa lolos dari hukuman, hahahaha",
                            "Kalau orang kepalanya botak didepan kan pinter, kalo botak di belakang kan kebanyakan mikir, kalo botak depan belakang apa??"
                    };

                    private string[] hukuman_e = {
                          "people1-smiling",
                          "people1-smile",
                          "people1-smile-evil"
                    }; 
                    //------>

                            private string[] hukuman_benar = {
                                    "Hahaha kamu pintar banget",
                                    "Hmm, soalnya terlalu mudah ya..",
                                    "Ah kamu pasti curang ya, kamu tetap harus dapat hukuman hahahahah"
                            };

                            private string[] hukuman_benar_e = {
                                                  "people1-smiling",
                                                  "people1-smile",
                                                  "people1-smile-evil"
                            };

                            private string[] hukuman_salah = {
                                    "Pertanyaan keg gitu aja gak bisa kamu",
                                    "Oke, baiklah kamu aku hukum sekarang"
                            };

                            private string[] hukuman_salah_e = {
                                                  "people1-smiling",
                                                  "people1-smile",
                                                  "people1-smile-evil"
                            };

                            private string[] hukuman_keluar = {
                                    "Cih, aku gak suka dipuji",
                                    "Kamu nggak jadi saya hukum",
                                    "Tapi kamu harus keluar dari ruangan ini sekarang juga",
                                    "Silahkan..."
                            };

                            private string[] hukuman_keluar_e = {
                                                  "people1-sad",
                                                  "people1-smile",
                                                  "people1-smile-evil"
                            };

                            private string[] hukuman_mencari = {
                                                            "Yak, hukuman kamu ambil bukuku yang ada di ruangan G.2.5",
                                                            "Tunggu apa lagi, ayo sekarang juga kesana"
                                                    };

                            private string[] hukuman_mencari_e = {
                                                             "people1-smile-evil"
                            };

                            private string[] berjalan_mencari = {
                                                             "Plak, plak, plak kamu berjalan menuju ruangan G.2.5",
                                                             "Kamu telah sampai didepan ruangan G.2.5"
                                                             
                            };

                            private string[] berjalan_mencari_e = {
                                                              "kaki2",
                                                              "pintu1",
                            };

                            
                             private string[] didepan_pintu = {
                                                             "Kamu mendorong-dorong pintu tapi tidak bisa dibuka",
                                                             "Pintunya ternyata terkunci, apa yang akan kamu lakukan?"
                            };

                            private string[] didepan_pintu_e = {
                                                             "pintu1",
                                                             "pintu-gembok"
                            };

                            private string[] bertanya_orang = {
                                                               "Ada apa masnya yang ganteng",
                                                               "Oh, kamu mau membuka pintu itu?",
                                                               "Aku punya kuncinya, rayu aku dulu nanti aku kasih",
                                                               "Coba rayu aku?"
                            };

                            private string[] bertanya_orang_e = {
                                                              "people2-smile",
                                                              "people2-flat-right",
                                                              "people2-flat-left",
                                                              
                            };
                             private string[] dobrak_pintu = {
                                                               "Dengan kekuatan penuh kamu mendobrak pintu",
                                                               "Dan akhirnya pintunya pun terbuka",
                                                               "Hei, Apa yang kamu lakukan!!!",
                                                               "Kamu itu ya mahasiswa gak tahu diri, kamu harus bertanggung jawab atas pintu itu",
                            };

                            private string[] dobrak_pintu_e = {
                                                              "dobrak-pintu",
                                                              "pintu_terbuka",
                                                              "people2-angry",
                                                              "people2-angry-left"
                            };

                            private string[] kembali_kemasnya = {
                                                               "Kenapa kamu kembali",
                                                               "Mana buku yang aku minta",
                                                               "Kenapa tidak kamu bawa!!!",
                                                               "Sana ambil atau kamu tidak boleh mengikuti dinus inside",
                            };

                            private string[] kembali_kemasnya_e = {
                                                              "people1-angry",
                                                              "people1-strange",
                                                              "people1-ew",
                                                              "people1-angry"
                            };

                            private string[] kembali_kemasnya_dapatkey = {
                                                               "Ini kak bukunya!!!!",
                                                               "Haha, terima kasih sudah mengambilkan buku ini",
                                                               "Karena kamu telah membantuku tidak masalah kamu tidak membawa barang2 dinus inside",
                                                               "Hukuman cuma itu kog, Kamu boleh mengikuti dinus inside dengan tenang"

                            };

                            private string[] kembali_kemasnya_dapatkey_e = {
                                                              "givebook",
                                                              "people1-smiling",
                                                              "people1-smile-left",
                                                              "people1-smile-right"
                            };

                            private string[] sukses_rayu = {
                                                               "Terima kasih, aku jadi meltings",
                                                               "Kamu pinter banget kalo ngerayu cwe, dasar tukang gombal ih",
                                                               "Yasudah, ini kuncinya kamu bisa buka pintu itu sekarang",
                                                               
                            };

                            private string[] sukses_rayu_e = {
                                                              "people2-terharu",
                                                              "people2-terharu-left",
                                                              "people2-terharu-right"
                            };

                            private string[] coba_lagi = {
                                                              "Coba rayuan yang lain",

                                                    };

                            private string[] coba_lagi_e = {
                                                              "people2-jijik",
                                                              "people2-flat-right",
                            };

                            private string[] gagal_rayu = {
                                                             "Pokoknya kamu harus rayu aku kalau mau aku kasih kunci",
                                                             "Yasudah kalau gak mau sana pergi",
                             };

                            private string[] gagal_rayu_e = {
                                                              "people2-jijik",
                                                              "people2-flat-right",
                            };

                            private string[] gagal_rayu_poll = {
                                                              "Dasar cowo jual mahal",
                                                              "Aku benci kamu!!!, sana pergi",
                                                              "Jangan kembali lagi",
                            };

                            private string[] gagal_rayu_poll_e = {
                                                              "people2-jijik",
                                                              "people2-angry",
                                                              "people2-angry-left"
                            };

                            private string[] masuk_ruangan = {
                                                               "Kamu membuka pintu G.2.5",
                                                               "Kamu menemukan buku mas hasan diatas meja",
                                                    };

                            private string[] masuk_ruangan_e = {
                                                              "pintu-terbuka",
                                                              "buku-atasmeja",
                            };
                            private string[] ambil_buku = {

                                                            "Kamu telah mendapatkan buku yang disuruh",
                             };

                            private string[] ambil_buku_e = {
                                                              "book_blue"
                            };
                            private string[] menang = {

                                                           "Akhirnya kamu telah dapat mengikuti dinus inside",
                                                           "END",
                                                     };

                            private string[] menang_e = {
                                                              "dinus"
                            };

    






















    /*
     *  START : INISIALISASI AWAL
     *  UPDATE : EXECUTE EVERYTIMES IN MS
     */

    //----> START AND UPDATE DI SINI

    // Use this for initialization
    void Start() {

        hide(p1); hide(p2); hide(p3); hide(p4); hideInput(panelInput);
        index = 0; fquestion = true; isGetKey = false; isGetBook = false;
        state = State.perkenalan;
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case State.perkenalan:
                perkenalan_state();
                break;

            case State.pertanyaan:
                pertanyaan_state();
                break;

            case State.sudahbawa:
                sudahbawa_state();
                break;
            case State.belumbawa:
                belumbawa_state();
                break;
            case State.hukuman:
                hukuman_state();
                break;

            case State.hukuman_benar:
                hukuman_benar_state();
                break;

            case State.hukuman_salah:
                hukuman_salah_state();
                break;

            case State.hukuman_keluar:
                hukuman_keluar_state();
                break;
            case State.hukuman_mencari:
                hukuman_mencari_state();
                break;
            case State.berjalan_mencari:
                changeBackground("pintu_terkunci");
                berjalan_mencari_state();
                break;
            case State.didepan_pintu:
                didepan_pintu_state();
                break;
            case State.bertanya_orang:
                bertanya_orang_state();
                break;
            case State.dobrak_pintu:
                dobrak_pintu_state();
                break;
            case State.kembali_kemasnya:
                changeBackground("depan_udinus");
                kembali_kemasnya_state();
                break;
            case State.sukses_rayu:
                sukses_rayu_state();
                break;
            case State.coba_lagi:
                coba_lagi_state();
                break;
            case State.gagal_rayu:
                gagal_rayu_state();
                break;
            case State.gagal_rayu_poll:
                gagal_rayu_poll_state();
                break;

            case State.masuk_ruangan:
                masuk_ruangan_state();
                break;
            case State.ambil_buku:
                ambil_buku_state();
                break;
            case State.menang:
                menang_state();
                break;
            case State.win:
                SceneManager.LoadScene("winScene");
                break;

            case State.game_over:
                SceneManager.LoadScene("failedScene");
                break;
           



        }

    }



    /*
     *  FUNGSI DAN PROSEDURE PENDUKUNG
     * 
     */

    //----> SEMUA FUNGSI DAN PROSEDURE AKAN BERADA DISINI

    void changePhoto(string res)
    {
        Sprite newSprite = Resources.Load<Sprite>(res);
        if (newSprite)
        {
            photo.sprite = newSprite;
        }
        else
        {
            Debug.LogError("Sprite not found", this);
        }
    }

    void changeBackground(string res)
    {
        Sprite newSprite = Resources.Load<Sprite>(res);
        if (newSprite)
        {
            background.sprite = newSprite;
        }
        else
        {
            Debug.LogError("Sprite not found", this);
        }
    }




    void hideInput(GameObject panel) // UNTUK MENYEMBUNYIKAN PANEL INPUT
    {
        panel.transform.localScale = new Vector3(0, 1, 1); // Set width to 0
    }

    private GameObject showInput(GameObject panel, string isi)
    {
        panel.transform.localScale = new Vector3(1, 1, 1); // Set width to 1
        panel.GetComponentInChildren<Text>().text = isi;


        return panel;
    }

    void hide(Button shape)
    {

        shape.transform.localScale = new Vector3(0, 1, 1);
    }

    Button show(Button shape, string text)
    {
        shape.onClick.RemoveAllListeners();
        shape.transform.localScale = new Vector3(1, 1, 1);
        shape.GetComponentInChildren<Text>().text = text;
        return shape;
    }

    void changeText(string text)
    {
        index++;
        speech.text = text;
        fquestion = false;
    }

    void changeState(State newstate)
    {
        index = 0;
        hide(p1); hide(p2); hide(p3); hide(p4); hideInput(panelInput);
        fquestion = true;
        state = newstate;
    }

    void initStandartState(string[] story, string[] picture, State nextState) // INSIALISASI STANDART STATE
    {
        try { speech.text = story[index]; changePhoto(picture[index]); } catch (Exception e) { }; 

        if (index < story.Length - 1)
        {
            show(p4, "NEXT").onClick.AddListener(delegate { changeText(story[index]); });
        }
        else
        {
            show(p4, "NEXT").onClick.AddListener(delegate { changeState(nextState); });

        }


    }

    private delegate void CallBack(); // DEFINE CALLBACK
   
    void initCostumeState(CallBack call1, CallBack call2,string text,int storyLength) // INSIALISASI COSTUME STATE
    {
        if (index == storyLength)
        {
            call1();
        }
        else if (index < storyLength)
        {
            if (fquestion)
            {
                speech.text = text;
            }
          
            call2();
        }


    }
    /*
     *  UNTUK MENAMBAHKAN STATE BISA DISINI
     *  STATE DAPAT BERUPA COSTUME DAN
     *  STATE STANDART
     * 
     */

    //----> SEMUA STATE AKAN BERADA DISINI

    void perkenalan_state()
    {

       initCostumeState(
       delegate {

            hide(p4);
            showInput(panelInput, "Masukkan nama kamu disini").GetComponentInChildren<Button>().onClick.AddListener(delegate {
                PlayerPrefs.SetString("playerName", panelInput.GetComponentsInChildren<Text>()[1].text);
                changeState(State.pertanyaan);
            });

        },
       delegate {

            show(p4, "NEXT").onClick.AddListener(delegate { try { changePhoto(perkenalan_e[index]); } catch (Exception e) { }; changeText(perkenalan[index]); });

        },
        "Hi , Selamat datang di dinus inside ",
        perkenalan.Length);

        
    }

    void pertanyaan_state()
    {

       initCostumeState(
       delegate {

           hide(p4);
           show(p1, "Sudah bawalahhh").onClick.AddListener(delegate { changeState(State.sudahbawa); }); ;
           show(p2, "Belum bawa :(").onClick.AddListener(delegate { changeState(State.belumbawa); }); ;

       },
       delegate {

           show(p4, "NEXT").onClick.AddListener(delegate { try { changePhoto(pertanyaan_e[index]); } catch (Exception e) { }; changeText(pertanyaan[index]); });

       },
       "Hmmm namamu " + PlayerPrefs.GetString("playerName") + ", nama yang bagus.",
        pertanyaan.Length);

    }

    void sudahbawa_state()
    {
        initStandartState(sudahbawa, sudahbawa_e, State.belumbawa);

    }


    void belumbawa_state()
    {
        initStandartState(belumbawa, belumbawa_e, State.hukuman);
    }

    void hukuman_state()
    {
        initCostumeState(
     delegate {

        
         show(p1, "Pinter Mikir").onClick.AddListener(delegate { changeState(State.hukuman_salah); }); 
         show(p2, "Suka Mikir").onClick.AddListener(delegate { changeState(State.hukuman_salah); }); ;
         show(p3, "Dia pikir dia pinter").onClick.AddListener(delegate { changeState(State.hukuman_benar); });
         show(p4, "Masnya yang pintar, maaf mas aku gak tahu").onClick.AddListener(delegate { changeState(State.hukuman_keluar); });

     },
     delegate {

         show(p4, "NEXT").onClick.AddListener(delegate { try { changePhoto(hukuman_e[index]); } catch (Exception e) { }; changeText(hukuman[index]); });

     },
     "Enaknya kamu aku apakan yaaa ",
      hukuman.Length);
    }


    void hukuman_benar_state()
    {
        initStandartState(hukuman_benar, hukuman_benar_e, State.hukuman_mencari);
    }

    void hukuman_salah_state()
    {
        initStandartState(hukuman_salah, hukuman_salah_e, State.hukuman_mencari);
    }

    void hukuman_keluar_state()
    {
        initStandartState(hukuman_keluar, hukuman_keluar_e, State.game_over);  // CONTOH UNTUK FAILED
    }

    void hukuman_mencari_state()
    {
        initStandartState(hukuman_mencari, hukuman_mencari_e, State.berjalan_mencari);
    }

    void berjalan_mencari_state()
    {
        initStandartState(berjalan_mencari, berjalan_mencari_e, State.didepan_pintu); 
    }

    void didepan_pintu_state()
    {
        if(!isGetKey)
        {
            initCostumeState(
            delegate {


                show(p1, "Bertanya orang sekitar").onClick.AddListener(delegate { changeState(State.bertanya_orang); });
                show(p2, "Kembali ke masnya tadi").onClick.AddListener(delegate { changeState(State.kembali_kemasnya); }); ;
                show(p3, "Bobol atau dobrak pintu").onClick.AddListener(delegate { changeState(State.dobrak_pintu); }); ;
                hide(p4);

            },
                delegate {

                    try { changePhoto(didepan_pintu_e[index]); } catch (Exception e) { };

                    show(p4, "NEXT").onClick.AddListener(delegate { changeText(didepan_pintu[index]); });

                },
               "Kamu ingin membuka pintu ",
             didepan_pintu.Length);
        }
        else
        {
            initCostumeState(
            delegate {


                show(p1, "Buka Pintu (kunci sudah didapatkan)").onClick.AddListener(delegate { changeState(State.masuk_ruangan); });
                show(p2, "Kembali ke masnya tadi").onClick.AddListener(delegate { changeState(State.kembali_kemasnya); }); ;
                show(p3, "Bobol atau dobrak pintu").onClick.AddListener(delegate { changeState(State.dobrak_pintu); }); ;
                hide(p4);

            },
                delegate {

                    try { changePhoto(didepan_pintu_e[index]); } catch (Exception e) { };

                    show(p4, "NEXT").onClick.AddListener(delegate { changeText(didepan_pintu[index]); });

                },
               "Kamu ingin membuka pintu ",
             didepan_pintu.Length);
        }

       
    }


    void masuk_ruangan_state()
    {

        initStandartState(masuk_ruangan, masuk_ruangan_e, State.ambil_buku);  // CONTOH UNTUK FAILED

    }


    void bertanya_orang_state()
    {
        initCostumeState(
     delegate {

         show(p1, "Satu hal yang tak kan pernah kutemuakan dari kamu adalah kekurangan, kau terlalu cantik untukku.").onClick.AddListener(delegate { changeState(State.coba_lagi); });
         show(p2, "Dilihat dari garis wajah, jangan kan aura-aura jahat. Aura kasih pun kalah sama kecantikanmu.").onClick.AddListener(delegate { changeState(State.coba_lagi); }); ;
         show(p3, "Aduh aku gak bisa rayu kamu").onClick.AddListener(delegate { changeState(State.gagal_rayu); });
         show(p4, "Dasar cewe genit, aku muak dengan semua ini").onClick.AddListener(delegate { changeState(State.gagal_rayu_poll); });

     },
     delegate {
         
         show(p4, "NEXT").onClick.AddListener( delegate { try { changePhoto(bertanya_orang_e[index]); } catch (Exception e) { }; changeText(bertanya_orang[index]); });

     },
    "Kamu berjalan dan bertanya ke orang sekitar",
     bertanya_orang.Length);
    }

    void dobrak_pintu_state()
    {
        initStandartState(dobrak_pintu, dobrak_pintu_e, State.game_over);  // CONTOH UNTUK FAILED
    }

    void kembali_kemasnya_state()
    {
        if(!isGetBook)
        {
            initStandartState(kembali_kemasnya, kembali_kemasnya_e, State.berjalan_mencari);
        }
        else
        {
            initStandartState(kembali_kemasnya_dapatkey, kembali_kemasnya_dapatkey_e, State.menang);
        }
        
    }

    void sukses_rayu_state()
    {
        isGetKey = true;
        initStandartState(sukses_rayu, sukses_rayu_e, State.didepan_pintu);
    }

    void coba_lagi_state()
    {
        initCostumeState(
        delegate {

           show(p1, "Aku cuma pengen hidup berkecukupan, cukup lihat senyum kamu tiap hari.").onClick.AddListener(delegate { changeState(State.coba_lagi); });
           show(p2, "Nyasar itu rugi banget, tapi aku nggak ngerasa rugi karena cintaku sudah nyasar ke hati kamu").onClick.AddListener(delegate { changeState(State.sukses_rayu); }); ;
           show(p3, "Kalau kursi, makin lama makin antik. Kalau kamu, makin lama makin cantik.").onClick.AddListener(delegate { changeState(State.coba_lagi); });
           show(p4, "Bentar, aku mau berfikir dulu").onClick.AddListener(delegate { changeState(State.gagal_rayu); });

        },
        delegate {

           show(p4, "NEXT").onClick.AddListener(delegate { try { changePhoto(coba_lagi_e[index]); } catch (Exception e) { }; changeText(coba_lagi[index]); });

        },
        "Ah, Rayuanmu biasa ajah",
        coba_lagi.Length);
    }

    void gagal_rayu_state()
    {
        initStandartState(gagal_rayu, gagal_rayu_e, State.kembali_kemasnya);
    }

    void gagal_rayu_poll_state()
    {
        initStandartState(gagal_rayu_poll, gagal_rayu_poll_e, State.game_over);
    }

    void ambil_buku_state()
    {
        isGetBook = true;
        initStandartState(ambil_buku, ambil_buku_e, State.kembali_kemasnya);

    }

    void menang_state()
    {
        initStandartState(menang, menang_e, State.win);
    }

 


}
