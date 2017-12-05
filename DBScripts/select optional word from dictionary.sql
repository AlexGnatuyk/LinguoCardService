select t1.value, t2.value from 
(select Words.value  as value from Words, Dictionary
where Words.id=Dictionary.english_id and Words.id = 1) t1,
(select Words.value  as value from Words, Dictionary
where Words.id=Dictionary.russian_id and Words.id = 2) t2