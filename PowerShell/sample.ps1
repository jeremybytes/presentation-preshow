$startTime = "11:15"
$url = "https://github.com/jeremybytes/code-is-for-humans"

$titleSlide = "TitleSlide.jpg"
$currentDirectory = $PWD.Path
$titleSlidePath = join-path $currentDirectory $titleSlide

$preshowPath = "C:\Development\Apps\PresentationPreshow\preshow\bin\Debug\net9.0-windows\preshow.exe"

& $preshowPath -t $titleSlidePath -s $startTime -u $url