using System;
using System.Collections.Generic;
using System.Linq;

namespace BT
{
    public enum Status
    {
        Success,
        Failure,
        Running
    }

    public class BTTester
    {
        BehaviourTree bt;
        void Test()
        {
            bt = new BehaviourTree();

            bt.root = new Root();
            Sequence sequence1 = new Sequence();
            Selector selector1 = new Selector();
            Condition condition1 = new Condition(() => true);
            Execution execution1 = new Execution(() => Status.Success);
            Execution execution2 = new Execution(() => Status.Success);
            Execution execution3 = new Execution(() => Status.Success);
            Execution execution4 = new Execution(() => Status.Success);

            bt.root.child = sequence1;
            sequence1.AddChild(execution1);
            sequence1.AddChild(condition1);
            sequence1.AddChild(selector1);
            condition1.child = execution2;
            selector1.AddChild(execution3);
            selector1.AddChild(execution4);
        }

        void TestTick()
        {
            bt.Tick();
        }
    }

    public class BehaviourTree
    {
        public Root root;

        public Status Tick()
        {
            return root.Invoke();
        }

        //build
        //=========================================================
        private Behaviour _current;
        private Stack<Composite> _compositeStack = new Stack<Composite>();
        public BehaviourTree StartBuild()
        {
            root = new Root();
            _current = root;
            return this;
        }

        public BehaviourTree Sequence()
        {
            Sequence sequence = new Sequence();
            AttachAsChild(_current, sequence);
            _compositeStack.Push(sequence);
            _current = sequence;
            return this;
        }

        private void AttachAsChild(Behaviour parent, Behaviour child)
        {
            if (parent is Composite)
            {
                (parent as Composite).AddChild(child);
            }
            else if (parent is IChild)
            {
                (parent as IChild).child = child;
            }
            else
            {
                throw new Exception("[BehaviourTree] : �ڽ��� ���� �θ��ൿ�� �ڽ��� �߰��Ϸ��� �õ��� �Ͼ");
            }
        }
    }

    public abstract class Behaviour
    {
        public abstract Status Invoke(out Behaviour leaf);
    }

    public interface IChild
    {
        Behaviour child { get; set; }
    }

    public class Root : Behaviour, IChild
    {
        public Behaviour child { get; set; }
        public Behaviour runningLeaf { get; set; }

        public Status Invoke()
        {
            if (runningLeaf == null)
                return Invoke(out Behaviour leaf);
            else
                return InvokeRunningLeaf();
        }

        public override Status Invoke(out Behaviour leaf)
        {
            Status tmpStatus = child.Invoke(out leaf);

            if (tmpStatus == Status.Running)
                runningLeaf = leaf;
            else
                runningLeaf = null;

            return tmpStatus;
        }

        public Status InvokeRunningLeaf()
        {
            Status tmpStatus = runningLeaf.Invoke(out Behaviour leaf);

            if (tmpStatus == Status.Running)
                runningLeaf = leaf;
            else
                runningLeaf = null;

            return tmpStatus;
        }
    }

    public class Condition : Behaviour, IChild
    {
        public Behaviour child { get; set; }
        private event Func<bool> _condition;

        public Condition(Func<bool> condition)
        {
            _condition = condition;
        }

        public override Status Invoke(out Behaviour leaf)
        {
            leaf = null;
            if (_condition.Invoke())
                return child.Invoke(out leaf);
            else
                return Status.Failure;
        }
    }

    public class Execution : Behaviour
    {
        public event Func<Status> _execute;

        public Execution(Func<Status> execute)
        {
            _execute = execute;
        }

        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            return _execute.Invoke();
        }
    }

    public abstract class Decorator : Behaviour, IChild
    {
        public Behaviour child { get; set; }
        public override Status Invoke(out Behaviour leaf)
        {
            return Decorate(child.Invoke(out leaf), out leaf);
        }
        
        public abstract Status Decorate(Status status, out Behaviour leaf);
    }

    public abstract class Composite : Behaviour
    {
        public List<Behaviour> children { get; set; }
        public Composite()
        {
            children = new List<Behaviour>();
        }

        public void AddChild(Behaviour child) => children.Add(child);
    }

    /// <summary>
    /// �ڽĵ��� �Ϸ��� �������� ó���ϴ� �ൿ.
    /// ��� �ڽ��� success �� ��ȯ�ϸ� success �� ��ȯ��.
    /// </summary>
    public class Sequence : Composite
    {
        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            Status result = Status.Failure;

            foreach (Behaviour child in children)
            {
                result = child.Invoke(out leaf);

                if (result != Status.Success)
                {
                    leaf = child;
                    return result;
                }
            }

            return Status.Success;
        }
    }

    public class RandomSequence : Composite
    {
        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            Status result = Status.Failure;

            //foreach (Behaviour child in children.OrderBy(c => UnityEngine.Random.Range(0, children.Count)))
            foreach (Behaviour child in children.OrderBy(c => Guid.NewGuid()))
            {
                result = child.Invoke(out leaf);

                if (result != Status.Success)
                {
                    leaf = child;
                    return result;
                }
            }

            return Status.Success;
        }
    }

    public class Filter : Sequence
    {
        public void AddCondition(Condition condition) => children.Insert(0, condition);
    }

    /// <summary>
    /// �����ϴ� �ڽ��� �����ϴ� �ൿ
    /// ��� �ڽ��� failure �� ��ȯ�ϸ� failure �� ��ȯ��.
    /// success/running ��ȯ �� �ڽ� ��ȸ�� �ߴ��ϰ� ����� ��ȯ��.
    /// </summary>
    public class Selector : Composite
    {
        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            Status result = Status.Failure;

            foreach (Behaviour child in children)
            {
                result = child.Invoke(out leaf);

                if (result != Status.Failure)
                {
                    leaf = child;
                    return result;
                }
            }

            return Status.Failure;
        }
    }

    /// <summary>
    /// �����ϴ� �ڽ��� �����ϴ� �ൿ
    /// ��� �ڽ��� failure �� ��ȯ�ϸ� failure �� ��ȯ��.
    /// success/running ��ȯ �� �ڽ� ��ȸ�� �ߴ��ϰ� ����� ��ȯ��.
    /// </summary>
    public class RandomSelector : Composite
    {
        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            Status result = Status.Failure;

            foreach (Behaviour child in children.OrderBy(c => Guid.NewGuid()))
            {
                result = child.Invoke(out leaf);

                if (result != Status.Failure)
                {
                    leaf = child;
                    return result;
                }
            }

            return Status.Failure;
        }
    }

    /// <summary>
    /// �ڽ��ൿ ��� ������� ��� �ڽ� �ൿ ������.
    /// ��ȯ���� ��ȯ ��å�� ���� ������.
    /// </summary>
    public class Pararell : Composite
    {
        public enum Policy
        {
            RequireOne,
            RequireAll,
        }

        private Policy _successPolicy;
        private Policy _failurePolicy;

        public Pararell(Policy successPolicy, Policy failurePolicy)
        {
            _successPolicy = successPolicy;
            _failurePolicy = failurePolicy;
        }

        public override Status Invoke(out Behaviour leaf)
        {
            leaf = this;
            Behaviour runningLeaf = null;
            int successCount = 0;
            int failureCount = 0;

            Status result = Status.Failure;
            foreach (Behaviour child in children)
            {
                result = child.Invoke(out leaf);

                switch (result)
                {
                    case Status.Success:
                        successCount++;
                        break;
                    case Status.Failure:
                        failureCount++;
                        break;
                    case Status.Running:
                        runningLeaf = leaf;
                        break;
                    default:
                        throw new Exception("[Pararell Behaviour] : �ൿ ��ȯ�� ����");
                }
            }

            if (runningLeaf != null)
            {
                leaf = runningLeaf;
                return Status.Running;
            }
            else if ((_successPolicy == Policy.RequireOne && successCount >= 1) ||
                     (_successPolicy == Policy.RequireAll && successCount >= children.Count))
            {
                return Status.Success;
            }
            else if ((_failurePolicy == Policy.RequireOne && failureCount >= 1) ||
                     (_failurePolicy == Policy.RequireAll && failureCount >= children.Count))
            {
                return Status.Failure;
            }
            else
            {
                throw new Exception("[Pararell Behaviour] : ��ȯ ��å ����");
            }
        }
    }
}
