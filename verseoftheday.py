r"""
Prerequisite: pip install opengraph_py3
Run the script, it will tell you a file location
Go to the file, should be ...Python\Python312\Lib\site-packages\opengraph_py3\opengraph.py
add features="html.parser" like this:

    def parser(self, html):
        if not isinstance(html,BeautifulSoup):
            doc = BeautifulSoup(html, features="html.parser")
"""

from opengraph_py3 import OpenGraph
print(OpenGraph(url="https://www.bible.com/verse-of-the-day", features="html.parser").description)