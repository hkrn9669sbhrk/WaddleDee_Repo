@echo off

rem ����I��
set resNormal=0
rem �ُ�I��
set resError=99
rem �o�͂���t�@�C������_log
set fileNameLog=logdata.log
rem �o�͂���t�@�C������_�ꎞ�t�@�C��
set fileNameTxt=response.txt
rem sqlcmd�ڑ����
rem set sqlcmd=sqlcmd -S �T�[�o�[�� -d DB�� -U ���[�U�[�� -P �p�X���[�h -i

set /p SERVERNAME="Server name -> "
set /p USERNAME="User name -> "
set /p PASSWORD="Password -> "

set sqlcmd=sqlcmd -S %SERVERNAME% -U %USERNAME% -P %PASSWORD% -i

rem sql�p�����[�^
set sqlParam=''

echo �v���O���������s���܂��B
echo �G���^�[�L�[�������Ă��������B

rem �ꎞ��~
pause

rem ��ʃ��b�Z�[�W�̃N���A
cls

rem -------�����L��------

rem SQLSERVER�ɐڑ�
rem [���s����SQL�t�@�C���̃p�X]�Ɏ��ۂ̃p�X�����

%sqlcmd% [���s����SQL�t�@�C���̃p�X] -v param=%sqlParam% -b -s, >> %fileNameLog%  2>&1

rem sqlcmd���s���ʂŏ����𕪊�
rem 0:����I�� 99:�ُ�I��

if %errorlevel% equ 0 (
 echo ����I�� > %fileNameLog%
 > %fileNameTxt% echo %resNormal%
)

 else (
 echo �ُ�I�� > %fileNameLog%
 type %~dp0\%fileNameLog%
 > %fileNameTxt% echo %resError%
)

rem -------�����L��------

echo �v���O�������I�����܂����B

pause
exit