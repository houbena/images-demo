pipeline {

    agent any

    stages {
        stage('Build') {
            environment {
                DTR_FQDN='ec2-54-174-122-88.compute-1.amazonaws.com:4443'
            }
            steps {
                sh 'docker image build -t ${DTR_FQDN}/jenkins/myapp:build-${BUILD_ID} .'
                sh 'docker image build --target testrunner -t myapp:testbuild-${BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:testbuild-${BUILD_ID}'
            }
        }
        stage('Deploy') {
            environment {
                DTR_FQDN='ec2-54-174-122-88.compute-1.amazonaws.com:4443'
                DTR_ACCESS_KEY = credentials('jenkins-dtr-access-token')
            }
            steps {
                //sh 'cd /ucpbundle ; eval "$(<env.sh)" ; docker service create myapp:build-${BUILD_ID}'
                //sh 'docker service create --replicas 4 nginx'
                sh 'docker login -u jenkins -p ${DTR_ACCESS_KEY} ${DTR_FQDN} ; docker image push ${DTR_FQDN}/jenkins/myapp:build-${BUILD_ID}
            }
        }
    }
}
