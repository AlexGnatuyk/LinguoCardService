select  Words.value
from Words,
(select Words.id as id
from Words
where Words.value = '�����') t1, Dictionary
where Dictionary.russian_id = t1.id and Dictionary.english_id=Words.id