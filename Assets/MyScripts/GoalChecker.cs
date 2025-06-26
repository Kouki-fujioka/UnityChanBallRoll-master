/*
 * namespace : ���O��� (�N���X��������) ���`
 * 
 * using : ���O��ԓ��̗v�f�ɐړ������ȗ����ăA�N�Z�X�\
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * private (�ȗ��\) : ���N���X����A�N�Z�X�\
 * 
 * protected : ���N���X, �T�u�N���X (�p����) ����A�N�Z�X�\
 * 
 * public : �S�N���X����A�N�Z�X�\ (�C���X�y�N�^����ݒ�\)
 * 
 * MonoBehaviour �N���X : �X�N���v�g���R���|�[�l���g�Ƃ��ăA�^�b�`�\�ɂ���t���[�����[�N, �Q�[���I�u�W�F�N�g�𐧌䂷��@�\�����
 */
public class GoalChecker : MonoBehaviour    // GoalChecker (MonoBehaviour �p��) �N���X�� public �Ƃ��Ē�`
{
    /*
     * �l�^ (Value Type) : �f�[�^ (�l) ��ێ�
     * 
     * �Q�ƌ^ (Reference Type) : �A�h���X (�Q��) ��ێ�
     */
    public GameObject unitychan;    // GameObject �^ (�Q�ƌ^) �̃t�B�[���h (unitychan) �� public �Ƃ��Ē�` (�C���X�y�N�^ : SD_unitychan_humanoid)
    public AudioSource gameBgm; // AudioSource �^ (�Q�ƌ^) �̃t�B�[���h (gameBgm) �� public �Ƃ��Ē�` (�C���X�y�N�^ : neuson_06 (Audio Source))
    public AudioSource goalBgm; // AudioSource �^ (�Q�ƌ^) �̃t�B�[���h (goalBgm) �� public �Ƃ��Ē�` (�C���X�y�N�^ : electro (Audio Source))
    public GameObject retryButton;  // GameObject �^ (�Q�ƌ^) �̃t�B�[���h (retryButton) �� public �Ƃ��Ē�` (�C���X�y�N�^ : Button)
    public Button buttonImage;  // Button �^ (�Q�ƌ^) �̃t�B�[���h (buttonImage) �� public �Ƃ��Ē�` (�C���X�y�N�^ : Button (Button))
    public TextMeshProUGUI buttonText;  // TextMeshProUGUI �^ (�Q�ƌ^) �̃t�B�[���h (buttonText) �� public �Ƃ��Ē�` (�C���X�y�N�^ : Text (TMP) (Text Mesh Pro UGUI))

    /*
     * MonoBehaviour.Start() : �S�R���|�[�l���g�� MonoBehaviour.Awake() �I����, �{�R���|�[�l���g�ƃA�^�b�`����Ă���Q�[���I�u�W�F�N�g�̗������L���ȏꍇ�� 1 �񂾂����s����郁�\�b�h
     */
    void Start()
    {
        /*
         * GameObject.SetActive(bool value)
         * value : �u�[���l (true, false)
         * �Q�[���I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ݒ�
         */
        retryButton.SetActive(false);   // �Q�[���I�u�W�F�N�g (Button) �𖳌���
    }

    /*
     * MonoBehaviour.Update() : �S�R���|�[�l���g�� MonoBehaviour.Start() �I����, �t���[�� (�s��, ���\�ˑ�) ���� 1 �񂾂����s����郁�\�b�h
     */
    void Update()
    {
        
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
         * Collider.gameObject.GetComponent<T>()
         * Collider : Collider �R���|�[�l���g (�Q��)
         * gameObject (�ȗ��\) : �Q�[���I�u�W�F�N�g (�Q��)
         * Collider �R���|�[�l���g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�� T �R���|�[�l���g (�Q��) ���擾 (�擾�s�\ �� null)
         * 
         * Rigidbody �R���|�[�l���g : �Q�[���I�u�W�F�N�g�ɕ���������ǉ�
         */
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;  // ����̃Q�[���I�u�W�F�N�g (Player) �� Rigidbody �R���|�[�l���g���擾 �� ���������𖳌���
        /*
         * GameObject.transform.LookAt(Transform target)
         * GameObject : �Q�[���I�u�W�F�N�g (�Q��)
         * transform : Transform �R���|�[�l���g (�Q��)
         * target : �����Ώ� (�Q��)
         * �Q�[���I�u�W�F�N�g�𒍎��Ώ� (�Q��) �̕����ɉ�]
         * 
         * Camera.main.transform : �Q�[���I�u�W�F�N�g (�^�O : MainCamera) �� Transform �R���|�[�l���g (�Q��)
         */
        unitychan.transform.LookAt(Camera.main.transform);  // �Q�[���I�u�W�F�N�g (SD_unitychan_humanoid) ���Q�[���I�u�W�F�N�g (Main Camera) �̕����ɉ�]
        /*
         * Animator �R���|�[�l���g : �Q�[���I�u�W�F�N�g�̃A�j���[�V�������Ǘ� (Animator Controller �g�p)
         * 
         * Animator.SetTrigger(string name) : �g���K�^�p�����[�^ (name) �� 1 �񂾂��L����
         */
        unitychan.GetComponent<Animator>().SetTrigger("Goal");  // �Q�[���I�u�W�F�N�g (SD_unitychan_humanoid) �� Animator �R���|�[�l���g���擾 �� �g���K�^�p�����[�^ (Goal) ��L����
        /*
         * AudioSource �R���|�[�l���g : �Q�[���I�u�W�F�N�g�ɃI�[�f�B�I�Đ��@�\��ǉ�
         * 
         * AudioSource.Stop() ; Audio Resurce ���~
         */
        gameBgm.Stop(); // Audio Resurce (neuson_06) ���~
        /*
         * AudioSource.Play()
         * Audio Resurce ���Đ�
         * �d���Đ� (AudioSource.Play() �̕��񏈗�) �s�\
         */
        goalBgm.Play(); // Audio Resurce (electro) ���Đ�
        retryButton.SetActive(true);    // �Q�[���I�u�W�F�N�g (Button) ��L����
        /*
         * Event System �I�u�W�F�N�g : UI ������Ǘ�, �V�[������ 1 �I�u�W�F�N�g
         * 
         * Canvas �I�u�W�F�N�g : UI �v�f (�{�^��, �摜, �e�L�X�g��) �̕\���̈� (�e�I�u�W�F�N�g)
         * 
         * Button �I�u�W�F�N�g : �{�^�����L�����o�X�ɕ\�� (�q�I�u�W�F�N�g)
         * 
         * Image �I�u�W�F�N�g : �摜���L�����o�X�ɕ\�� (�q�I�u�W�F�N�g)
         */
        buttonImage.GetComponent<Image>().enabled = true;   // �Q�[���I�u�W�F�N�g (Button) �� Image �R���|�[�l���g���擾 �� �L����
        /*
         * Text �I�u�W�F�N�g : �e�L�X�g���L�����o�X�ɕ\�� (�q�I�u�W�F�N�g)
         */
        buttonText.text = "RETRY";  // �e�L�X�g (RETRY) �� UI �ɕ\��
    }

    public void RetryStage()    // �Q�[���I�u�W�F�N�g (Button) ���N���b�N���ꂽ�ꍇ�� 1 �񂾂����s����郁�\�b�h (�C���X�y�N�^ (onClick) : GoalChecker.RetryStage())
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �V�[���������[�h (���X�^�[�g)
    }
}
