using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JogoScript : MonoBehaviour
{
    [SerializeField] Estatisticas estatisticas;
    public GameVariables gameVariables;

    [Header("Quadrados")]
    public GameObject[,] AxA_squares = new GameObject[9, 9];
    public GameObject[] squares;
    public GameObject QuadradoSelecionado;
    public TextMeshProUGUI NumeroPrincipal;
    

    [Header("Quadrados")]
    public int linha = 0;
    public int coluna = 0;

    [Header("Dificuldade")]
    public TextMeshProUGUI textoDificuldade;

    [Header("Tempo")]
    public bool TempoAtivoNesseJogo;
    public TextMeshProUGUI textoTempo;
    Coroutine TimerRoutine;
    [SerializeField] int TempoEmSegundos;


    [Header("Cores")]
    Color ClearBlue = new Color(203f / 255f, 233 / 255f, 245 / 255f, 255 / 255f);
    Color SlightlyDarkerBlue = new Color(130f / 255f, 181 / 255f, 277 / 255f, 255 / 255f);
    Color Selected = new Color(128f / 255f, 212 / 255f, 245 / 255f, 255 / 255f);
    Color AquaGreen = new Color(42f / 255f, 160 / 255f, 137 / 255f, 255 / 255f);
    Color Sgray = new Color(50f / 255f, 50 / 255f, 50 / 255f, 255 / 255f);

    [Header("Outros")]
    public Image BotaoLapisImagem;
    public bool lapisAtivo = false;


    #region Funções dos Quadrados

    public void ColocarJogoDentroDosQuadrados()
    {
        StartCoroutine(JogoNosQuadrados());
    }

    public IEnumerator JogoNosQuadrados()
    {
        Initiate();
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 81; i++)
        {
            CellsScript cellsScript = squares[i].GetComponent<CellsScript>();
            if (gameVariables.AtualSudokuGameIncompleto[i] == '0')
            {
                cellsScript.NumeroPrincipal.text = "";
                cellsScript.podeEditar = true;
                continue;
            }

            cellsScript.NumeroPrincipal.text = gameVariables.AtualSudokuGameIncompleto[i].ToString();
            cellsScript.podeEditar = false;
        }
        TextoDificuldade();

        if (gameVariables.jogoAtualComTempoAtivado == true)
        {
            print("Começando tempo 1");
            ComecarTempo();
        }

    }

    public void ColocarJogoPreenchidoDentroDosQuadrados()
    {
        StartCoroutine(JogoPreenchidoNosQuadrados());
    }

    IEnumerator JogoPreenchidoNosQuadrados()
    {
        Initiate();
        yield return new WaitForSeconds(0.1f);
        if(gameVariables.AtualSudokuGamePreenchido != "")
        {
            for (int i = 0; i < 81; i++)
            {
                CellsScript cellsScript = squares[i].GetComponent<CellsScript>();
                if (gameVariables.AtualSudokuGamePreenchido[i] == '0')
                {
                    continue;
                }

                cellsScript.NumeroPrincipal.text = gameVariables.AtualSudokuGamePreenchido[i].ToString();
                cellsScript.NumeroPrincipal.color = AquaGreen;
                cellsScript.podeEditar = true;
            }
        }
        
    }

    public void BotaoInserirNumero(int numero)
    {
        CellsScript cellsScript = QuadradoSelecionado.GetComponent<CellsScript>();
        
        if (lapisAtivo && NumeroPrincipal.text == "")
        {
            cellsScript.LigarDesligarNumeroLapis(numero);
            return;
        }

        if (QuadradoSelecionado != null && cellsScript != null && cellsScript.podeEditar == true)
        {
            DesiluminarTodosOsQuadrados();
            cellsScript.DesligarTodosOsNumeros();
            NumeroPrincipal.text = numero.ToString();
            NumeroPrincipal.color = AquaGreen;
            NumeroPrincipal.fontStyle = FontStyles.Bold;
        }
        IluminarNumeros();
        ConferirJogoDentroDosQuadrados();
    }

    public void BotaoApagarNumero()
    {
        CellsScript cellsScript = QuadradoSelecionado.GetComponent<CellsScript>();
        if (QuadradoSelecionado != null && cellsScript != null && cellsScript.podeEditar == true)
            NumeroPrincipal.text = "";

        IluminarQuadrados();
    }

    public void IluminarQuadradoSelecionado()
    {
        QuadradoSelecionado.GetComponent<Image>().color = SlightlyDarkerBlue;
    }

    public void DesiluminarTodosOsQuadrados()
    {
        foreach (GameObject quadrado in squares)
        {
            quadrado.GetComponent<Image>().color = Color.white;
            quadrado.GetComponent<CellsScript>().NumeroPrincipal.fontStyle = FontStyles.Normal;
        }
    }

    public void ResetarTodosOsQuadrados()
    {
        DesiluminarTodosOsQuadrados();
        foreach (GameObject quadrado in squares)
        {
            CellsScript cellsScript = quadrado.GetComponent<CellsScript>();
            cellsScript.podeEditar = true;
            cellsScript.NumeroPrincipal.text = "";
            cellsScript.NumeroPrincipal.fontStyle = FontStyles.Normal;
            cellsScript.NumeroPrincipal.color = Color.black;
        }
    }

    public void IluminarQuadrados()
    {
        string pos = QuadradoSelecionado.name;
        linha = Convert.ToInt16(Char.GetNumericValue(pos[0]));
        coluna = Convert.ToInt16(Char.GetNumericValue(pos[1]));

        DesiluminarTodosOsQuadrados();
        IluminarGrade3x3(linha, coluna);
        IluminarLinha(linha);
        IluminarColuna(coluna);
        IluminarNumeros();
        IluminarQuadradoSelecionado();
    }

    private void IluminarGrade3x3(int linha, int coluna)
    {
        GameObject[,] grid9x9squares = new GameObject[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                grid9x9squares[i, j] = AxA_squares[3 * (linha / 3) + i, 3 * (coluna / 3) + j];
            }
        }
        
        foreach (var item in grid9x9squares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }

    }

    private void IluminarLinha(int linha)
    {
        GameObject[] rowsquares = new GameObject[9];
        for (int coluna = 0; coluna < 9; coluna++)
        {
            rowsquares[coluna] = AxA_squares[linha, coluna];
        }

        foreach (var item in rowsquares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }
    }

    private void IluminarColuna(int col)
    {
        GameObject[] columnquares = new GameObject[9];
        for (int row = 0; row < 9; row++)
        {
            columnquares[row] = AxA_squares[row, col];
        }

        foreach (var item in columnquares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }

    }

    public void IluminarNumeros()
    {
        GameObject[] NumerosIguais = new GameObject[81];
        if (NumeroPrincipal.text != "" & NumeroPrincipal.text != "0")
        {
            for (int i = 0; i < 81; i++)
            {
                if (squares[i].GetComponent<CellsScript>().NumeroPrincipal.text == NumeroPrincipal.text)
                {
                    NumerosIguais[i] = squares[i];
                }
            } 
        }

        foreach (var numero in NumerosIguais)
        {
            if (numero != null)
            {
                numero.gameObject.GetComponent<Image>().color = SlightlyDarkerBlue;
                numero.GetComponent<CellsScript>().NumeroPrincipal.fontStyle = FontStyles.Bold;
            }

        }

    }

    public string EncontrarPosicao(string name)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (AxA_squares[i, j].name == name)
                {
                    string pos = $"{i}{j}";
                    return pos;
                }
            }
        }
        return null;
    }

    public void AtivarDesativarLapis()
    {
        lapisAtivo = !lapisAtivo;
    }

    #endregion

    #region Fade
    public void FadePanel(bool in_out, CanvasGroup panel)
    {
        StartCoroutine(Fade(in_out, panel));
    }

    IEnumerator Fade(bool in_out, CanvasGroup panel)
    {
        if (in_out == true)
        {
            panel.interactable = true;
            panel.gameObject.SetActive(true);
            LeanTween.alphaCanvas(panel, 1, 0.5f);
        }
        else
        {
            panel.interactable = false;
            LeanTween.alphaCanvas(panel, 0, 0.5f);
            yield return new WaitForSeconds(0.6f);
            panel.gameObject.SetActive(false);
        }
        yield return null;
    }
    #endregion

    #region Funções de tempo
    public void ComecarTempo()
    {
        TimerRoutine = StartCoroutine(GameTimer());
    }

    public void PararTempo()
    {
        if (TimerRoutine != null)
        {
            StopCoroutine(TimerRoutine);
        }
    }

    public void ZerarTimer()
    {
        TempoEmSegundos = 0;
        int minutes = Mathf.FloorToInt(TempoEmSegundos / 60);
        int seconds = Mathf.FloorToInt(TempoEmSegundos % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        textoTempo.text = timerString;
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            yield return new WaitForSeconds(1);
            TempoEmSegundos += 1;
            int minutes = Mathf.FloorToInt(TempoEmSegundos / 60);
            int seconds = Mathf.FloorToInt(TempoEmSegundos % 60);
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            textoTempo.text = timerString;
        }
    }

    
    #endregion

    #region Funções de Vitória ou não
    public void ConferirJogoDentroDosQuadrados()
    {
        var SolucaoDoJogador = new System.Text.StringBuilder();
        for (int i = 0; i < 81; i++)
        {
            string textoCelula = squares[i].GetComponent<CellsScript>().NumeroPrincipal.text;
            if (textoCelula == "")
            {
                SolucaoDoJogador.Append("0");
            }
            SolucaoDoJogador.Append(textoCelula);
        }

        gameVariables.AtualSudokuGamePreenchido = JogoPreenchidoPeloJogador(SolucaoDoJogador.ToString());

        if (SolucaoDoJogador.ToString().Contains("0"))
        {
            return;
        }

        if (SolucaoDoJogador.ToString() == gameVariables.AtualSudokuGameCompleto)
        {
            VenceuJogo();
            PararTempo();
        }
        else
        {
            NaoVenceuJogo();
            print(SolucaoDoJogador.ToString());
        }
        
    }

    public void VenceuJogo()
    {
        estatisticas.AdiconarValores(gameVariables.dificuldadeAtual, pjogoFinalizado: 1, ptempo: TempoEmSegundos);
        GetComponent<Popups>().PopupVoceVenceu();
    }

    public void NaoVenceuJogo()
    {
        GetComponent<Popups>().PopupJogoIncorreto();
    }
    #endregion

    #region Funções Gerais

    private void Initiate()
    {
        // Create an Array of Arrays with the Squares GameObjects
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                AxA_squares[i, j] = squares[count];
                count++;
            }
        }
        
    }

    public void TextoDificuldade()
    {
        if (gameVariables.dificuldadeAtual == 0)
        {
            textoDificuldade.text = "Novato";
        }

        if (gameVariables.dificuldadeAtual == 1)
        {
            textoDificuldade.text = "Fácil";
        }

        if (gameVariables.dificuldadeAtual == 2)
        {
            textoDificuldade.text = "Médio";
        }

        if (gameVariables.dificuldadeAtual == 3)
        {
            textoDificuldade.text = "Difícil";
        }

        if (gameVariables.dificuldadeAtual == 4)
        {
            textoDificuldade.text = "Especialista";
        }

        if (gameVariables.dificuldadeAtual == 5)
        {
            textoDificuldade.text = "Terror";
        }
    }

    public void SalvarJogoVelho()
    {
        gameVariables.dificuldadeJogoVelho = gameVariables.dificuldadeAtual;
        gameVariables.tempoJogoVelho = TempoEmSegundos;
        gameVariables.jogoVelhoComTempoAtivado = gameVariables.jogoAtualComTempoAtivado;

        gameVariables.VelhoSudokuGameCompleto = gameVariables.AtualSudokuGameCompleto;
        gameVariables.VelhoSudokuGameIncompleto = gameVariables.AtualSudokuGameIncompleto;
        gameVariables.VelhoSudokuGamePreenchido = gameVariables.AtualSudokuGamePreenchido;

        DeletarJogoAtual();

        gameVariables.GetComponent<JogarScript>().VerificarSeExisteJogoVelho();

        // Salvar o jogo no json
    }

    public void ContinuarJogoVelho()
    {
        // Carregar o jogo do json

        gameVariables.dificuldadeAtual = gameVariables.dificuldadeJogoVelho;
        TempoEmSegundos = gameVariables.tempoJogoVelho;
        gameVariables.jogoAtualComTempoAtivado = gameVariables.jogoVelhoComTempoAtivado;

        gameVariables.AtualSudokuGameCompleto = gameVariables.VelhoSudokuGameCompleto;
        gameVariables.AtualSudokuGameIncompleto = gameVariables.VelhoSudokuGameIncompleto;
        gameVariables.AtualSudokuGamePreenchido = gameVariables.VelhoSudokuGamePreenchido;

        DeletarJogoVelho();
    }

    public void DeletarJogoVelho()
    {
        gameVariables.VelhoSudokuGameCompleto = "";
        gameVariables.VelhoSudokuGameIncompleto = "";
        gameVariables.VelhoSudokuGamePreenchido = "";
    }

    public void DeletarJogoAtual()
    {
        gameVariables.AtualSudokuGameCompleto = "";
        gameVariables.AtualSudokuGameIncompleto = "";
        gameVariables.AtualSudokuGamePreenchido = "";
    }

    string JogoPreenchidoPeloJogador(string JogoPreenchido)
    {
        var SolucaoDoJogador = new System.Text.StringBuilder();
        for (int i = 0; i < 81; i++)
        {
            if(JogoPreenchido[i] == gameVariables.AtualSudokuGameIncompleto[i])
                SolucaoDoJogador.Append("0");
            else
                SolucaoDoJogador.Append(JogoPreenchido[i]);
        }
        return SolucaoDoJogador.ToString();
    }

    public void PintarBotãoLapis()
    {
        if (lapisAtivo)
        {
            BotaoLapisImagem.color = Color.green;
        }
        else
        {
            BotaoLapisImagem.color = Color.white;
        }
    }

    #endregion
}
