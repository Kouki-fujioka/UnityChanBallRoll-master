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
public class Rotator : MonoBehaviour    // Rotator (MonoBehaviour �p��) �N���X�� public �Ƃ��Ē�`
{
    /*
     * MonoBehaviour.Start() : �S�R���|�[�l���g�� MonoBehaviour.Awake() �I����, �{�R���|�[�l���g�ƃA�^�b�`����Ă���Q�[���I�u�W�F�N�g�̗������L���ȏꍇ�� 1 �񂾂����s����郁�\�b�h
     */
    void Start()
    {
        
    }

    /*
     * MonoBehaviour.Update() : �S�R���|�[�l���g�� MonoBehaviour.Start() �I����, �t���[�� (�s��, ���\�ˑ�) ���� 1 �񂾂����s����郁�\�b�h
     */
    void Update()
    {
        /*
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
         * Vector3 �^ : (x, y, z)
         * 
         * new ���Z�q : �N���X, �\����, �z�񓙂̃C���X�^���X (�V�K�I�u�W�F�N�g) �𐶐�
         * 
         * �v���p�e�B : �A�N�Z�X (�N���X�O �� �����o) �𐧌䂷�郁�\�b�h
         * 
         * Component.gameObject{ get; } : �S�R���|�[�l���g�̓v���p�e�B��p���ăA�^�b�`����Ă���Q�[���I�u�W�F�N�g (�Q��) ���擾�\
         * 
         * this.gameObject.transform.Rotate(Vector3 eulers, Space relativeTo = Space.Self)
         * this (�ȗ��\) : �{�R���|�[�l���g (�Q��)
         * gameObject (�ȗ��\) : �Q�[���I�u�W�F�N�g (�Q��)
         * transform : Transform �R���|�[�l���g (�Q��)
         * eulers : ��]�� (�l)
         * relativeTo : �g�p��� (�l)
         * relativeTo == Space.Self �� ���[�J����� (�q�I�u�W�F�N�g == �{�R���|�[�l���g, �e�I�u�W�F�N�g == �Q�[���I�u�W�F�N�g)
         * relativeTo == Space.World �� ���[���h���
         * �{�R���|�[�l���g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�ɉ�]�� (�l) ��t�^
         * 
         * Time.deltaTime : �O�t���[������̌o�ߎ��� (�b)
         * 
         * 60FPS (�t���[�� / �b) �̏ꍇ
         * Time.deltaTime = 1 / 60 �� 0.01667 (��������)
         * Vector3(15, 30, 45) * 0.01667 �� (0.25, 0.5, 0.75) (�p�x / �t���[��)
         * (0.25, 0.5, 0.75) * 60 = (15, 30, 45) (�p�x / �b)
         * 
         * 30FPS (�t���[�� / �b) �̏ꍇ
         * Time.deltaTime = 1 / 30 �� 0.03333 (��������)
         * Vector3(15, 30, 45) * 0.03333 �� (0.5, 1, 1.5) (�p�x / �t���[��)
         * (0.25, 0.5, 0.75) * 30 = (15, 30, 45) (�p�x / �b)
         */
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);    // �Q�[���I�u�W�F�N�g (Item) �� 1 �b�Ԃ� (15, 30, 45) �x��]
    }
}
