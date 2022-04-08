window.startupIndexPage = (problem) => {
    console.log(problem)
    $(() => {
        let $e = $("#codedash-problem-block")[0]
        
        // Fix CRLF if Blazor on Windows
        const src = problem.source.replaceAll(/\r\n/g, '\n');
        console.log({thing: src});
        const nls = (() => {
            let r = [0]
            for (let i = 0; i < src.length; i++) {
                if (src[i] === '\n') r.push(i);
            }
            return r;
        })();
        console.log(nls);
        let beginIdx = 0;
        for (let i of problem.blanks) {
            const pos = nls[i.line - 1] + (i.column - 1);
            console.log(pos);
            const text = src.substring(beginIdx, pos);
            console.log(text);
            $e.append(document.createTextNode(text));
            
            const textField = document.createElement('input');
            textField.size = i.length;
            $e.append(textField);
            beginIdx = pos;
        }
        if (beginIdx < src.length) {
            const text = src.substring(beginIdx);
            $e.append(document.createTextNode(text));
        }
    });
}
window.readIndexPage = () => {
    
}