/*
 * namespace : ���O��� (�N���X��������) ���`
 * 
 * using : ���O��ԓ��̗v�f�ɐړ������ȗ����ăA�N�Z�X�\
 */
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * private (�ȗ��\) : ���N���X����A�N�Z�X�\
 * 
 * protected : ���N���X, �T�u�N���X (�p����) ����A�N�Z�X�\
 * 
 * public : �S�N���X����A�N�Z�X�\ (�C���X�y�N�^����ݒ�\)
 * 
 * MonoBehaviour �N���X : �X�N���v�g���R���|�[�l���g�Ƃ��ăA�^�b�`�\�ɂ���t���[�����[�N, �Q�[���I�u�W�F�N�g�𐧌䂷��@�\�����
 */
public class PlayerController : MonoBehaviour   // PlayerController (MonoBehaviour �p��) �N���X�� public �Ƃ��Ē�`
{
    /*
     * �l�^ (Value Type) : �f�[�^ (�l) ��ێ�
     * 
     * �Q�ƌ^ (Reference Type) : �A�h���X (�Q��) ��ێ�
     */
    Rigidbody rb;   // Rigidbody �^ (�Q�ƌ^) �̃t�B�[���h (rb) �� private �Ƃ��Ē�`
    public float speed; // float �^ (�l�^) �̃t�B�[���h (speed) �� public �Ƃ��Ē�` (�C���X�y�N�^ : 10)
    int count;  // int �^ (�l�^) �̃t�B�[���h (count) �� private �Ƃ��Ē�`
    public TextMeshProUGUI countText;   // TextMeshProUGUI �^ (�Q�ƌ^) �̃t�B�[���h (countText) �� public �Ƃ��Ē�` (�C���X�y�N�^ : CountText (Text Mesh Pro UGUI))
    AudioSource getSE;  // AudioSource �^ (�Q�ƌ^) �̃t�B�[���h (getSE) �� private �Ƃ��Ē�`

    /*
     * MonoBehaviour.Start() : �S�R���|�[�l���g�� MonoBehaviour.Awake() �I����, �{�R���|�[�l���g�ƃA�^�b�`����Ă���Q�[���I�u�W�F�N�g�̗������L���ȏꍇ�� 1 �񂾂����s����郁�\�b�h
     */
    void Start()
    {
        /* 
         * this.gameObject.GetComponent<T>()
         * this (�ȗ��\) : �{�R���|�[�l���g (�Q��)
         * gameObject (�ȗ��\) : �Q�[���I�u�W�F�N�g (�Q��)
         * �{�R���|�[�l���g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�� T �R���|�[�l���g (�Q��) ���擾 (�擾�s�\ �� null)
         *
         * Rigidbody �R���|�[�l���g : �Q�[���I�u�W�F�N�g�ɕ���������ǉ�
         */
        rb = GetComponent<Rigidbody>(); // �Q�[���I�u�W�F�N�g (Player) �� Rigidbody �R���|�[�l���g���擾
        count = 0;  // ������
        SetCountText(); // �e�L�X�g (�A�C�e���擾��) �� UI �ɕ\��
        /*
         * AudioSource �R���|�[�l���g : �Q�[���I�u�W�F�N�g�ɃI�[�f�B�I�Đ��@�\��ǉ�
         */
        getSE = GetComponent<AudioSource>();    // �Q�[���I�u�W�F�N�g (Player) �� AudioSource �R���|�[�l���g���擾
    }

    /*
     * MonoBehaviour.Update() : �S�R���|�[�l���g�� MonoBehaviour.Start() �I����, �t���[�� (�s��, ���\�ˑ�) ���� 1 �񂾂����s����郁�\�b�h
     */
    // void Update()
    // {
    //     /*
    //      * Input.GetAxis("Horizontal")
    //      * Horizontal : Input Manager ����L�[�ݒ�\
    //      * �ړ��L�[ (A, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ -1)
    //      * �ړ��L�[ (D, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ 1)
    //      */
    //     float moveH = Input.GetAxis("Horizontal");  // x ������ (���E) �̓��͒l���i�[ (-1 ~ 1)
    //     /*
    //      * Input.GetAxis("Vertical")
    //      + Vertical : Input Manager ����L�[�ݒ�\
    //      * �ړ��L�[ (S, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ -1)
    //      * �ړ��L�[ (W, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ 1)
    //      */
    //     float moveV = Input.GetAxis("Vertical");    // z ������ (�O��) �̓��͒l���i�[ (-1 ~ 1)
    //     /*
    //      * Vector3 �^ : (x, y, z)
    //      * 
    //      * new ���Z�q : �N���X, �\����, �z�񓙂̃C���X�^���X (�V�K�I�u�W�F�N�g) �𐶐�
    //      */
    //     Vector3 move = new Vector3(moveH, 0, moveV);    // ������
    //     /*
    //      * Rigidbody.AddForce(Vector3 force)
    //      * force : �� (���[���h���)
    //      * �Q�[���I�u�W�F�N�g (Rigidbody.gameObject) �ɗ� (���[���h���) ��t�^
    //      */
    //     rb.AddForce(move * speed);  // �Q�[���I�u�W�F�N�g (Player) �ɗ� (move * speed) ��t�^
    // }

    /*
     * MonoBehaviour.FixedUpdate() : �S�R���|�[�l���g�� MonoBehaviour.Start() �I����, �t���[�� (���) ���� 1 �񂾂����s����郁�\�b�h
     */
    void FixedUpdate()
    {
        /*
         * Input.GetAxis("Horizontal")
         * Horizontal : Input Manager ����L�[�ݒ�\
         * �ړ��L�[ (A, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ -1)
         * �ړ��L�[ (D, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ 1)
         */
        float moveH = Input.GetAxis("Horizontal");  // x ������ (���E) �̓��͒l���i�[ (-1 ~ 1)
        /*
         * Input.GetAxis("Vertical")
         * Vertical : Input Manager ����L�[�ݒ�\
         * �ړ��L�[ (S, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ -1)
         * �ړ��L�[ (W, ��) �������Ă��钷���ɉ����ď����̖߂�l��ԋp (0 ~ 1)
         */
        float moveV = Input.GetAxis("Vertical");    // z ������ (�O��) �̓��͒l���i�[ (-1 ~ 1)
        /*
         * Vector3 �^ : (x, y, z)
         * 
         * new ���Z�q : �N���X, �\����, �z�񓙂̃C���X�^���X (�V�K�I�u�W�F�N�g) �𐶐�
         */
        Vector3 move = new Vector3(moveH, 0, moveV);    // ������
        /*
         * �������Z : MonoBehaviour.FixedUpdate() ����������
         * 
         * Rigidbody.AddForce(Vector3 force)
         * force : �� (���[���h���)
         * �Q�[���I�u�W�F�N�g (Rigidbody.gameObject) �ɗ� (���[���h���) ��t�^
         */
        rb.AddForce(move * speed);  // �Q�[���I�u�W�F�N�g (Player) �ɗ� (move * speed) ��t�^
    }

    /*
     * Collider �R���|�[�l���g : �Q�[���I�u�W�F�N�g�ɓ����蔻�蓙��ǉ�
     * �g���K�@�\ (isTrigger == true) �� Rigidbody �̏Փ˔��薳��, �g���K�C�x���g (OnTrigger) ����
     * �Փˋ@�\ (isTrigger == false) �� Rigidbody �̏Փ˔���L��, �Փ˃C�x���g (OnCollision) ����
     * 
     * MonoBehaviour.OnTriggerEnter(Collider other)
     * other : ����� Collider �R���|�[�l���g (�Q��)
     * �Q�[���I�u�W�F�N�g (����) : Collider �R���|�[�l���g�K�{
     * �Q�[���I�u�W�F�N�g (�Е�) : Rigidbody �R���|�[�l���g, �g���K�@�\�K�{
     * �Q�[���I�u�W�F�N�g (�g���K�@�\) �̗̈�N������ 1 �񂾂����s����郁�\�b�h
     */
    private void OnTriggerEnter(Collider other)
    {
        /*
         * �v���p�e�B : �A�N�Z�X (�N���X�O �� �����o) �𐧌䂷�郁�\�b�h
         * 
         * Component.gameObject{ get; } : �S�R���|�[�l���g�̓v���p�e�B��p���ăA�^�b�`����Ă���Q�[���I�u�W�F�N�g (�Q��) ���擾�\
         * 
         * Collider.gameObject.CompareTag(string tag)
         * Collider : Collider �R���|�[�l���g (�Q��)
         * gameObject (�ȗ��\) : �Q�[���I�u�W�F�N�g (�Q��)
         * tag : �^�O (�l)
         * gameObject.tag == tag �� true
         * gameObject.tag != tag �� false
         */
        if (other.gameObject.CompareTag("Item"))    // ����̃Q�[���I�u�W�F�N�g�̃^�O�� Item (�C���X�y�N�^����ݒ�) �̏ꍇ
        {
            /*
             * GameObject.SetActive(bool value)
             * value : �u�[���l (true, false)
             * �Q�[���I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ݒ�
             */
            other.gameObject.SetActive(false);  // ����̃Q�[���I�u�W�F�N�g (Item) �𖳌���
            count = count + 1;  // �C���N�������g
            // Debug.Log(count);   // �R���\�[���ɃA�C�e���擾����\��
            SetCountText(); // �e�L�X�g (�A�C�e���擾��) �� UI �ɕ\��
            /*
             * AudioSource.Play()
             * Audio Resurce ���Đ�
             * �d���Đ� (AudioSource.Play() �̕��񏈗�) �s�\
             */
            getSE.Play();   // Audio Resurce (ItemGet) ���Đ�
        }
        else if (other.gameObject.CompareTag("Bottom")) // ����̃Q�[���I�u�W�F�N�g�̃^�O�� Bottom (�C���X�y�N�^����ݒ�) �̏ꍇ
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �V�[���������[�h (���X�^�[�g)
        }
    }

    void SetCountText()
    {
        /*
         * Event System �I�u�W�F�N�g : UI ������Ǘ�, �V�[������ 1 �I�u�W�F�N�g
         * 
         * Canvas �I�u�W�F�N�g : UI �v�f (�{�^��, �摜, �e�L�X�g��) �̕\���̈� (�e�I�u�W�F�N�g)
         * 
         * Text �I�u�W�F�N�g : �e�L�X�g���L�����o�X�ɕ\�� (�q�I�u�W�F�N�g)
         */
        countText.text = "GetNum : " + count.ToString();  // �e�L�X�g (�A�C�e���擾��) �� UI �ɕ\��
    }
}
