using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    public Model GetModel() => model;
    private AudioSource _Audios;
    private MeshRenderer _MeshRenderer;
    private Rigidbody _rb;




    View _view;

   public Model model;

    public Controller controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            model.Grounded = true; 

       
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            model.Grounded = false;
    }




    void Start()
    {
        _Audios = GetComponent<AudioSource>();
        _MeshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();

        _view = new View(_Audios, _MeshRenderer, this);

        model = new Model();

        model.CurrentStats = model;

        controller = new Controller(model, _view, _rb);
    }

    // Update is called once per frame
    void Update()
    {
        controller.ProcessInputs();
        model.JumpPlayer(_rb);
        model.MovePlayer(_rb);
    }
}
