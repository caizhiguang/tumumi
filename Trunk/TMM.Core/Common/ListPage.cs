using System;
using System.Collections;

namespace TMM.Core.Common
{
    /// <summary>
    /// ��ҳ������ģ����
    /// </summary>
    [Serializable]
    public class ListPage
    {
        /// <summary>
        /// ��ǰҳ�ļ�¼�б�
        /// </summary>
        private IList list;

        /// <summary>
        /// ��ǰҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        private int firstResult;

        /// <summary>
        /// ÿһҳ�ļ�¼��
        /// </summary>
        private int maxResults;

        /// <summary>
        /// ȫ����¼������
        /// </summary>
        private int allResults;

        /// <summary>
        /// ��һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        private int prevPage;

        /// <summary>
        /// ��һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        private int nextPage;

        /// <summary>
        /// ���һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        private int lastPage;

        /// <summary>
        /// ��ǰҳ�ǵڼ�ҳ
        /// </summary>
        private int currPage;

        /// <summary>
        /// ���ж���ҳ
        /// </summary>
        private int pages;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="list">��ǰҳ�ļ�¼�б�</param>
        /// <param name="firstResult">��ǰҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����</param>
        /// <param name="maxResults">ÿһҳ�ļ�¼��</param>
        /// <param name="allResults">ȫ����¼������</param>
        public ListPage(IList list, int firstResult, int maxResults, int allResults)
        {
            this.list = list;
            this.firstResult = firstResult;
            this.maxResults = maxResults;
            this.allResults = allResults;

            this.prevPage = firstResult - maxResults;
            if (this.prevPage < 0)
            {
                this.prevPage = 0;
            }
            if (allResults <= maxResults)
            {
                this.lastPage = 0;
            }
            else
            {
                this.lastPage = allResults % maxResults;
                this.lastPage = (this.lastPage == 0) ? (allResults - maxResults) : (allResults - this.lastPage);
            }
            this.nextPage = firstResult + maxResults;
            if (this.nextPage > this.lastPage)
            {
                this.nextPage = this.lastPage;
            }

            pages = allResults % maxResults;
            if (pages == 0)
                pages = allResults / maxResults;
            else
                pages = allResults / maxResults + 1;

            currPage = (firstResult + maxResults) / maxResults;
        }
        public ListPage( int firstResult, int maxResults, int allResults)
        {
            
            this.firstResult = firstResult;
            this.maxResults = maxResults;
            this.allResults = allResults;

            this.prevPage = firstResult - maxResults;
            if (this.prevPage < 0)
            {
                this.prevPage = 0;
            }
            if (allResults <= maxResults)
            {
                this.lastPage = 0;
            }
            else
            {
                this.lastPage = allResults % maxResults;
                this.lastPage = (this.lastPage == 0) ? (allResults - maxResults) : (allResults - this.lastPage);
            }
            this.nextPage = firstResult + maxResults;
            if (this.nextPage > this.lastPage)
            {
                this.nextPage = this.lastPage;
            }

            pages = allResults % maxResults;
            if (pages == 0)
                pages = allResults / maxResults;
            else
                pages = allResults / maxResults + 1;

            currPage = (firstResult + maxResults) / maxResults;
        }
        /// <summary>
        /// ��ǰҳ�ļ�¼�б�
        /// </summary>
        public IList List
        {
            get { return list; }
        }

        /// <summary>
        /// ��ǰҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        public int FirstResult
        {
            get { return firstResult; }
        }

        /// <summary>
        /// ÿһҳ�ļ�¼��
        /// </summary>
        public int MaxResults
        {
            get { return maxResults; }
        }

        /// <summary>
        /// ȫ����¼������
        /// </summary>
        public int AllResults
        {
            get { return allResults; }
        }

        /// <summary>
        /// ��һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        public int PrevPage
        {
            get { return prevPage; }
        }

        /// <summary>
        /// ��һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        public int NextPage
        {
            get { return nextPage; }
        }

        /// <summary>
        /// ���һҳ�ĵ�һ����¼��ȫ����¼�е�����������0Ϊ��ʼ����
        /// </summary>
        public int LastPage
        {
            get { return lastPage; }
        }

        /// <summary>
        /// ��ǰҳ�ǵڼ�ҳ
        /// </summary>
        public int CurrPage
        {
            get { return currPage; }
        }

        /// <summary>
        /// ���ж���ҳ
        /// </summary>
        public int Pages
        {
            get { return pages; }
        }
    }
}
