/*
 * namespace : ���O��� (�N���X��������) ���`
 * 
 * using : ���O��ԓ��̗v�f�ɐړ������ȗ����ăA�N�Z�X�\
 */
using UnityEngine;

/*
 * private (�ȗ��\) : ���N���X����A�N�Z�X�\
 * 
 * protected : ���N���X, �T�u�N���X (�p����) ����A�N�Z�X�\
 * 
 * public : �S�N���X����A�N�Z�X�\ (�C���X�y�N�^����ݒ�\)
 * 
 * MonoBehaviour �N���X : �X�N���v�g���R���|�[�l���g�Ƃ��ăA�^�b�`�\�ɂ���t���[�����[�N, �Q�[���I�u�W�F�N�g�𐧌䂷��@�\�����
 */
public class PlayerFollower : MonoBehaviour // PlayerFollower (MonoBehaviour �p��) �N���X�� public �Ƃ��Ē�`
{
    /*
     * �l�^ (Value Type) : �f�[�^ (�l) ��ێ�
     * 
     * �Q�ƌ^ (Reference Type) : �A�h���X (�Q��) ��ێ�
     */
    public GameObject player;   // GameObject �^ (�Q�ƌ^) �̃t�B�[���h (player) �� public �Ƃ��Ē�` (�C���X�y�N�^ : Player)
    Vector3 offset; // Vector3 �^ (�l�^) �̃t�B�[���h (offset) �� private �Ƃ��Ē�`

    /*
     * MonoBehaviour.Start() : �S�R���|�[�l���g�� MonoBehaviour.Awake() �I����, �{�R���|�[�l���g�ƃA�^�b�`����Ă���Q�[���I�u�W�F�N�g�̗������L���ȏꍇ�� 1 �񂾂����s����郁�\�b�h
     */
    void Start()
    {
        /*
         * Vector3 �^ : (x, y, z)
         * 
         * Transform �R���|�[�l���g : �Q�[���I�u�W�F�N�g�̍��W, ��], �X�P�[��, �e�q�֌W���Ǘ�, �S�Q�[���I�u�W�F�N�g������ (�C���X�y�N�^ : ���[�J�����)
         * 
         * �e�q�֌W : �e�I�u�W�F�N�g���ړ�, ��], �g��k�� �� �q�I�u�W�F�N�g���ړ�, ��], �g��k��
         * 
         * ���[�J����� (���[�J�����W (transform.localPosition), ���[�J����] (transform.localRotation), ���[�J���X�P�[�� (transform.localScale)) : �e�I�u�W�F�N�g�
         * 
         * ���[���h��� (���[���h���W (transform.position), ���[���h��] (transform.rotation), ���[�J���X�P�[�� (transform.localScale)) : �V�[���
         * 
         * �e�I�u�W�F�N�g == �V�[�� �� ���[�J����� == ���[���h���
         * 
         * �v���p�e�B : �A�N�Z�X (�N���X�O �� �����o) �𐧌䂷�郁�\�b�h
         * 
         * Component.gameObject{ get; } : �S�R���|�[�l���g�̓v���p�e�B��p���ăA�^�b�`����Ă���Q�[���I�u�W�F�N�g (�Q��) ���擾�\
         *
         * this.gameObject.transform.position
         * this (�ȗ��\) : �{�R���|�[�l���g (�Q��)
         * gameObject (�ȗ��\) : �Q�[���I�u�W�F�N�g (�Q��)
         * transform : Transform �R���|�[�l���g (�Q��)
         * position : ���[���h���W (�l)
         * �{�R���|�[�l���g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�̃��[���h���W (�l) ���擾
         * 
         * GameObject.transform.position
         * GameObject : �Q�[���I�u�W�F�N�g (�Q��)
         * transform : Transform �R���|�[�l���g (�Q��)
         * position : ���[���h���W (�l)
         * �Q�[���I�u�W�F�N�g�̃��[���h���W (�l) ���擾
         */
        offset = this.transform.position - player.transform.position;   // �Q�[���I�u�W�F�N�g�� (Main Camera, Player) �̋��� (�I�t�Z�b�g) ���v�Z
    }

    /*
     * MonoBehaviour.Update() : �S�R���|�[�l���g�� MonoBehaviour.Start() �I����, �t���[�� (�s��, ���\�ˑ�) ���� 1 �񂾂����s����郁�\�b�h
     */
    // void Update()
    // {
    //     this.transform.position = player.transform.position + offset;    // �Q�[���I�u�W�F�N�g�� (Main Camera, Player) �̋��� (�I�t�Z�b�g) ��ێ�
    // }

    /*
     * MonoBehaviour.LateUpdate() : �S�R���|�[�l���g�� MonoBehaviour.Update() �I������ 1 �񂾂����s����郁�\�b�h
     */
    void LateUpdate()   // Player �� Main Camera
    {
        this.transform.position = player.transform.position + offset;   // �Q�[���I�u�W�F�N�g�� (Main Camera, Player) �̋��� (�I�t�Z�b�g) ��ێ�
    }
}
