using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameEstatisticas
{
    public int jogoIniciado_n;
    public int jogoFinalizado_n;
    public int jogoAbandonado_n;
    public int melhorTempo_n;
    public int piorTempo_n;

    public int jogoIniciado_f;
    public int jogoFinalizado_f;
    public int jogoAbandonado_f;
    public int melhorTempo_f;
    public int piorTempo_f;

    public int jogoIniciado_m;
    public int jogoFinalizado_m;
    public int jogoAbandonado_m;
    public int melhorTempo_m;
    public int piorTempo_m;

    public int jogoIniciado_d;
    public int jogoFinalizado_d;
    public int jogoAbandonado_d;
    public int melhorTempo_d;
    public int piorTempo_d;

    public int jogoIniciado_e;
    public int jogoFinalizado_e;
    public int jogoAbandonado_e;
    public int melhorTempo_e;
    public int piorTempo_e;

    public int jogoIniciado_t;
    public int jogoFinalizado_t;
    public int jogoAbandonado_t;
    public int melhorTempo_t;
    public int piorTempo_t;

    public GameEstatisticas(int jogoIniciado_n, int jogoFinalizado_n, int jogoAbandonado_n, int melhorTempo_n, int piorTempo_n, int jogoIniciado_f, int jogoFinalizado_f, int jogoAbandonado_f, int melhorTempo_f, int piorTempo_f, int jogoIniciado_m, int jogoFinalizado_m, int jogoAbandonado_m, int melhorTempo_m, int piorTempo_m, int jogoIniciado_d, int jogoFinalizado_d, int jogoAbandonado_d, int melhorTempo_d, int piorTempo_d, int jogoIniciado_e, int jogoFinalizado_e, int jogoAbandonado_e, int melhorTempo_e, int piorTempo_e, int jogoIniciado_t, int jogoFinalizado_t, int jogoAbandonado_t, int melhorTempo_t, int piorTempo_t)
    {
        this.jogoIniciado_n = jogoIniciado_n;
        this.jogoFinalizado_n = jogoFinalizado_n;
        this.jogoAbandonado_n = jogoAbandonado_n;
        this.melhorTempo_n = melhorTempo_n;
        this.piorTempo_n = piorTempo_n;
        this.jogoIniciado_f = jogoIniciado_f;
        this.jogoFinalizado_f = jogoFinalizado_f;
        this.jogoAbandonado_f = jogoAbandonado_f;
        this.melhorTempo_f = melhorTempo_f;
        this.piorTempo_f = piorTempo_f;
        this.jogoIniciado_m = jogoIniciado_m;
        this.jogoFinalizado_m = jogoFinalizado_m;
        this.jogoAbandonado_m = jogoAbandonado_m;
        this.melhorTempo_m = melhorTempo_m;
        this.piorTempo_m = piorTempo_m;
        this.jogoIniciado_d = jogoIniciado_d;
        this.jogoFinalizado_d = jogoFinalizado_d;
        this.jogoAbandonado_d = jogoAbandonado_d;
        this.melhorTempo_d = melhorTempo_d;
        this.piorTempo_d = piorTempo_d;
        this.jogoIniciado_e = jogoIniciado_e;
        this.jogoFinalizado_e = jogoFinalizado_e;
        this.jogoAbandonado_e = jogoAbandonado_e;
        this.melhorTempo_e = melhorTempo_e;
        this.piorTempo_e = piorTempo_e;
        this.jogoIniciado_t = jogoIniciado_t;
        this.jogoFinalizado_t = jogoFinalizado_t;
        this.jogoAbandonado_t = jogoAbandonado_t;
        this.melhorTempo_t = melhorTempo_t;
        this.piorTempo_t = piorTempo_t;
    }
}
